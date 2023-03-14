#! python deploy_dll_files.py
# -*- coding: utf-8 -*-

# 環境変数 `MY_DOCUMENTS_PATH` を設定する必要あり

import sys
import os
import shutil
import yaml

CONFIG = {}

OPTIONS = {}

OPTION_DEFAULTS: dict[str, any] = {
    'update_yaml': False,
    'update_markdown': False,
    'update_font': False,
    'varbose': False,
    'deploy_to_cyross_folder': False,
    'debug': False,
    'clean': False,
    'test': 0
}

OPTION_SWITCHES: dict[str, list[str]] = {
    'update_yaml': ['-Y','--UPDATE_YAML'],
    'update_markdown': ['-M','--UPDATE_MARKDOWN'],
    'update_font': ['-F','--UPDATE_FONT'],
    'deploy_to_cyross_folder': ['-CY','--DEPLOY_TO_CYROSS_FOLDER'],
    'debug': ['-D','--DEBUG'],
    'clean': ['-CL','--CLEAN'],
    'varbose': ['-V','--VARBOSE'],
    }

OPTION_PARAMETERS: dict[str, dict[str, any]] = {
    'test': { 'option': ['-T','--TEST'], 'type': int }
    }

def abort_program() -> None:
    print('スクリプトを終了します')
    exit()

def print_varbose(message: str) -> None:
    if OPTIONS['varbose']:
        print(message)

def load_config(is_debug: bool) -> dict[str, any]:
    config_filepath: str = './deploy_files.yaml' if not is_debug else './deploy_files_debug.yaml'

    if not os.path.exists(config_filepath):
        print(f'[ERROR]ファイルが見つかりません: {config_filepath}')
        abort_program()

    try:
        with open(config_filepath, 'r', encoding='utf-8') as config_file:
            config: dict[str, any] = yaml.safe_load(config_file)
    except yaml.YAMLError as e:
        print('[ERROR]コンフィグファイル読み込み中にエラーが発生しました')
        print(f'[ERROR][file]{config_filepath}')
        print(f'[ERROR][message]{e}')
        abort_program()

    return config

def analyze_option_parameter(args: list[str], index: int, value_type: type) -> any:
    if index == len(args)-1:
        print('[WARN]オプションに値がありません: {args[index]}')
        abort_program()

    try:
        value = value_type(args[index + 1])
    except ValueError as e:
        print('[ERROR]オプションの値が指定の型に変換できません')
        print(f'[ERROR]option: {args[index]} value: {args[index + 1]}')
        abort_program()

    return value

def analyze_commandline_options(command_line_args: list[str]) -> dict[str, list[str] | bool]:
    # オプション未指定のときはデフォルト値を使用
    if len(command_line_args) < 2:
        return OPTION_DEFAULTS.copy()

    options: dict[any] = {}
    args: list[str] = command_line_args[1:]
    next_pass: bool = False

    for i in range(len(args)):
        # このコマンドライン引数はオプションの値のためスルー
        if next_pass:
            next_pass = False
            continue

        arg: str = args[i]
        upper_arg: str = arg.upper()
        found: bool = False

        # スイッチ型オプションを検索
        for key in OPTION_SWITCHES.keys():
            found = upper_arg in OPTION_SWITCHES[key]
            if found:
                options[key] = True
                break

        # パラメータ型オプションを検索
        if not found:
            for key in OPTION_PARAMETERS.keys():
                param_info: dict[str, any] = OPTION_PARAMETERS[key]
                found = upper_arg in param_info['option']
                if found:
                    options[key] = analyze_option_parameter(args, i, param_info['type'])
                    next_pass = True
                    break

        if not found:
            print(f'[WARN]存在しないオプションです : {arg}')

    # 指定していないものはデフォルト値で
    result_options = OPTION_DEFAULTS.copy()
    result_options.update(options)

    return result_options

def delete_file_from_folder(filename: str, folders: list[str], doc_path: str) -> None:
    for dir_base in folders:
        delete_file(os.path.join(dir_base.format(doc_path), filename))

def delete_file(path: str):
    print_varbose(f'delete {path}')
    try:
        os.remove(path)
    except FileNotFoundError:
        print(f'[INFO]ファイルが見つかりません: {path}')

def delete_files(dst_file_folders: list[str], vegas_script_files: list[str], my_documents_path: str) -> None:
    # VEGAS HELPER
    delete_file_from_folder(
        CONFIG['vegas_helper_file_name'],
        dst_file_folders,
        my_documents_path)

    # VEGAS SCRIPT
    for file_info in vegas_script_files:
        delete_file_from_folder(
            file_info['file'],
            dst_file_folders,
            my_documents_path)

def copy_file_to_folder(
    filename: str,
    file_dir: str,
    folders: list[str],
    doc_path: str,
    is_yaml: bool = False,
    update_yaml: bool = False) -> None:
    # コピーする条件:
    #   - DLLファイル: 無条件
    #   - YAMLファイル: 新規書き込みか、update_yamlオプション指定時
    src_file_path: str = os.path.join(file_dir, filename)
    for dst_dir_base in folders:
        dst_dir: str = dst_dir_base.format(doc_path)
        dst_file_path: str = os.path.join(dst_dir, filename)
        if not is_yaml or (is_yaml and (not os.path.exists(dst_file_path) or update_yaml)):
            copy_file(src_file_path, dst_file_path)
        else:
            print(f'[NOTICE]not copy : {filename}')

def copy_file(src_path: str, dst_path: str):
    print_varbose(f'copy {src_path}\n  -> {dst_path}')
    try:
        shutil.copyfile(src_path, dst_path)
    except FileNotFoundError:
        print(f'[ERROR]ファイルが見つかりません: {src_path}')
        abort_program()
    except shutil.SameFileError:
        print(f'[ERROR]コピー元とコピー先のファイルパスが同じです: {src_path} -> {dst_path}')
        abort_program()

def deploy_files(dst_file_folders: list[str], vegas_script_files: list[str], my_documents_path: str) -> None:
    # VEGAS HELPER
    copy_file_to_folder(
        CONFIG['vegas_helper_file_name'],
        CONFIG['vegas_helper_file_dir'],
        dst_file_folders,
        my_documents_path)

    # VEGAS SCRIPT
    for file_info in vegas_script_files:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            dst_file_folders,
            my_documents_path)

    # YAML FILES
    for file_info in CONFIG['vegas_yaml_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            dst_file_folders,
            my_documents_path,
            True,
            OPTIONS['update_yaml'])

    # MarkDown FILES
    for file_info in CONFIG['vegas_markdown_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            dst_file_folders,
            my_documents_path,
            True,
            OPTIONS['update_markdown'])

    # Font FILES
    for file_info in CONFIG['vegas_font_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            dst_file_folders,
            my_documents_path,
            True,
            OPTIONS['update_font'])

if __name__ == '__main__':
    print('start deploy...')

    OPTIONS: dict[str, any] = analyze_commandline_options(sys.argv)

    CONFIG: dict[str, any] = load_config(OPTIONS['debug'])

    print_varbose(f'options = {OPTIONS}')

    my_documents_path: str = os.getenv('MY_DOCUMENTS_PATH')

    if my_documents_path is None:
        print('[NOTICE]MY_DOCUMENTS_PATH環境変数の設定が必須です')
        print('[例]C:\\Users\\Hoge\\Documents\\vegas_extension_files -> MY_DOCUMENTS_PATH="C:\\Users\\Hoge\\Documents"')
        quit()

    dst_vegas_script_folders = [CONFIG['dst_vegas_script_folder']]
    dst_vegas_extension_folders = [CONFIG['dst_vegas_extension_folder']]

    print('delete to vegas script folder...')
    delete_files(dst_vegas_script_folders, CONFIG['vegas_script_files'], my_documents_path)
    print('delete to vegas application extension folder...')
    delete_files(dst_vegas_extension_folders, CONFIG['vegas_extension_files'], my_documents_path)

    if OPTIONS['clean']:
        print('cleaning complete!')
        quit()

    if OPTIONS['deploy_to_cyross_folder']:
        dst_vegas_script_folders.append(CONFIG['cyross_vegas_script_folder'])
        dst_vegas_extension_folders.append(CONFIG['dst_vegas_extension_folder'])

    print('copy to vegas script folder...')
    deploy_files(dst_vegas_script_folders, CONFIG['vegas_script_files'], my_documents_path)
    print('copy to vegas application extension folder...')
    deploy_files(dst_vegas_extension_folders, CONFIG['vegas_extension_files'], my_documents_path)

    print('complete!')
