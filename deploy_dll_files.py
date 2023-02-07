#! python deploy_dll_files.py
# -*- coding: utf-8 -*-

# 環境変数 `MY_DOCUMENTS_PATH` を設定する必要あり

import os
import shutil
import yaml

with open('./deploy_dll_files.yaml', 'r', encoding='utf-8') as yaml_file:
    SETTING = yaml.safe_load(yaml_file)

def abort_program():
    print('スクリプトを終了します')
    exit()

def copy_file_to_folder(dll_filename, dll_file_dir, folders, doc_path):
    src_dll_file_path = os.path.join(dll_file_dir, dll_filename)
    for dst_dir_base in folders:
        dst_dir = dst_dir_base.format(doc_path)
        dst_dll_file_path = os.path.join(dst_dir, dll_filename)
        copy_file(src_dll_file_path, dst_dll_file_path)

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

    print('get my documents path')

    my_documents_path = os.getenv('MY_DOCUMENTS_PATH')

    if my_documents_path is None:
        print('[NOTICE]MY_DOCUMENTS_PATH環境変数の設定が必須です')
        print('[例]C:\\Users\\Hoge\\Documents\\vegas_extension_files -> MY_DOCUMENTS_PATH="C:\\Users\\Hoge\\Documents"')
        quit()

    # VEGAS HELPER
    copy_file_to_folder(
        SETTING['vegas_helper_file_name'],
        SETTING['vegas_helper_file_dir'],
        SETTING['dst_vegas_script_folder'],
        my_documents_path
        )
    copy_file_to_folder(
        SETTING['vegas_helper_file_name'],
        SETTING['vegas_helper_file_dir'],
        SETTING['dst_vegas_extension_folder'],
        my_documents_path
        )

    # VEGAS SCRIPT
    for file_info in SETTING['vegas_script_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            SETTING['dst_vegas_script_folder'],
            my_documents_path
            )

    # VEGAS APPLICATION EXTENSION
    for file_info in SETTING['vegas_extension_files']:
        copy_file_to_folder(
            file_info['file'],
            file_info['dir'],
            SETTING['dst_vegas_extension_folder'],
            my_documents_path
            )

    print('\ncomplete!')
