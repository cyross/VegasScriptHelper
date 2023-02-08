#! python deploy_dll_files.py
# -*- coding: utf-8 -*-

# 環境変数 `MY_DOCUMENTS_PATH` を設定する必要あり

import sys
import os
import shutil
import yaml

CONFIG = {}

OPTIONS = {}

OPTION_DEFAULTS = {
    'update_yaml': False
}

OPTION_SWITCHES = {
    'update_yaml': ['-Y','--UPDATE_YAML']
    }

def abort_program():
    print('スクリプトを終了します')
    exit()

def update_option_params(options, option_params):
    if len(option_params) > 0:
        param_key = option_params.pop(0)
        options[param_key] = option_params if len(option_params) > 0 else True
        print(f'UPDATE OPTION: {param_key}, VALUE: {options[param_key]}')

def analyze_commandline_options(command_line_args: list[str]) -> dict[str, list[str] | bool]:
    # オプション未指定のときはデフォルト値を使用
    if len(command_line_args) < 2:
        return OPTION_DEFAULTS.copy()

    options = {}

    args: list[str] = command_line_args[1:]

    option_params = []

    for arg in args:
        upper_arg: str = arg.upper()

        for key in OPTION_SWITCHES.keys():
            if upper_arg in OPTION_SWITCHES[key]:
                update_option_params(options, option_params)
 
                option_params = [key]
            elif len(option_params) == 0:
                print(f'[WARN]Illegal option : {arg}')
            else:
                option_params.append[arg]

    update_option_params(options, option_params)

    if len(options.keys()) > 0:
        print('')
    
    # 指定していないものはデフォルト値で
    result_options = OPTION_DEFAULTS.copy()
    result_options.update(options)

    return result_options

def copy_file_to_folder(filename, file_dir, folders, doc_path, is_yaml = False, update_yaml = False):
    # コピーする条件:
    #   - DLLファイル: 無条件
    #   - YAMLファイル: 新規書き込みか、update_yamlオプション指定時
    src_file_path = os.path.join(file_dir, filename)
    for dst_dir_base in folders:
        dst_dir = dst_dir_base.format(doc_path)
        dst_file_path = os.path.join(dst_dir, filename)
        if not is_yaml or (is_yaml and (not os.path.exists(dst_file_path) or update_yaml)):
            copy_file(src_file_path, dst_file_path)
        else:
            print(f'not copy : {filename}')

def copy_file(src_path, dst_path):
    print(f'copy {src_path}\n  -> {dst_path}')
    try:
        shutil.copyfile(src_path, dst_path)
    except FileNotFoundError:
        print(f'[ERROR]ファイルが見つかりません: {src_path}')
        abort_program()
    except shutil.SameFileError:
        print(f'[ERROR]コピー元とコピー先のファイルパスが同じです: {src_path} -> {dst_path}')
        abort_program()
    except Exception as e:
        print(f'[ERROR]エラーが発生しました: {e}')
        abort_program()

if __name__ == '__main__':
    print('start deploy...\n')

    with open('./deploy_dll_files.yaml', 'r', encoding='utf-8') as yaml_file:
        CONFIG = yaml.safe_load(yaml_file)

    print('analyze command line options...\n')

    OPTIONS = analyze_commandline_options(sys.argv)

    print(f'options = {OPTIONS}')

    print('get my documents path\n')

    my_documents_path = os.getenv('MY_DOCUMENTS_PATH')

    if my_documents_path is None:
        print('[NOTICE]MY_DOCUMENTS_PATH環境変数の設定が必須です')
        print('[例]C:\\Users\\Hoge\\Documents\\vegas_extension_files -> MY_DOCUMENTS_PATH="C:\\Users\\Hoge\\Documents"')
        quit()

    # VEGAS HELPER
    copy_file_to_folder(
        CONFIG['vegas_helper_file_name'],
        CONFIG['vegas_helper_file_dir'],
        CONFIG['dst_vegas_script_folder'],
        my_documents_path
        )
    copy_file_to_folder(
        CONFIG['vegas_helper_file_name'],
        CONFIG['vegas_helper_file_dir'],
        CONFIG['dst_vegas_extension_folder'],
        my_documents_path
        )

    # VEGAS SCRIPT
    for file_info in CONFIG['vegas_script_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            CONFIG['dst_vegas_script_folder'],
            my_documents_path
            )

    # VEGAS APPLICATION EXTENSION
    for file_info in CONFIG['vegas_extension_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            CONFIG['dst_vegas_extension_folder'],
            my_documents_path
            )

    # YAML FILES
    for yaml_file_name in CONFIG['vegas_yaml_files']:
        copy_file_to_folder(
            yaml_file_name,
            CONFIG['vegas_yaml_file_dir'],
            CONFIG['dst_vegas_script_folder'],
            my_documents_path,
            True,
            OPTIONS['update_yaml'])

    for yaml_file_name in CONFIG['vegas_yaml_files']:
        copy_file_to_folder(
            yaml_file_name,
            CONFIG['vegas_yaml_file_dir'],
            CONFIG['dst_vegas_extension_folder'],
            my_documents_path,
            True,
            OPTIONS['update_yaml'])

    print('\ncomplete!')
