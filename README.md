# VegasScriptHelper

## 概要

VEGASでの動画作成の補助に役立つ拡張機能集。
格納機能として、以下のものが利用できます。

- VegasScriptLauncher
  - 各便利機能(スクリプト)をボタンクリックで起動できるランチャ
- ShowTrackLength
  - トラック中の全イベントの長さを出力(余白込み)
- ShowSelectedEventTime
  - 選択したイベントの開始時間と長さを表示
- ShowTips
  - VEGASを使う上でのTipsを表示
  - TipsはTips.mdを編集することで各自で変更可能

また、ランチャーから起動している各スクリプトは「ツール」のスクリプトからでも実行可能です。

- AddMediaBinInSelectedTrack
  - 選択したトラックのメディアを指定のビンに登録する
  - ビン名は新規・既存のどちらでも可
- ApplySerifuColor
  - 選択したビデオトラック内のテキストイベントの文字色とアウトライン(色・幅)を声優毎に適応する
  - 適応したあと、接頭辞(声優名)を削除することも可能
- AssignVideoEventFromAudioEvent
  - 選択したビデオトラック内のイベントを、対となるオーディオトラック内のイベントの長さに合わせる
  - その時、それぞれのイベントをグループ化可能
- CreateInitialBin
  - ボイロ動画を作成する際に便利なビンをあらかじめ作成する
  - ビン名は変更可能
- CreateJimaku
  - ボイロ動画作成に必要な字幕や音声を一括設置
  - 声優名の切り分け・声優名表示トラックの作成、背景画像の指定もできる
- CreateJimakuBackground
  - 字幕の背景画像を追加
  - 音声毎にイベントを作るか、音声トラック全体に作るかの選択が可能
- EditEventTime
  - 選択したイベントの開始時間と長さを時間単位で編集する
- ExpandFirstVideoEvent
  - 選択したビデオトラック内の最初のイベントの開始位置・長さを、選択したオーディオトラックの長さに合わせる
- InsertAudioFileFromDirectory
  - 選択したディレクトリ内の音声ファイル全てを、オーディオトラックに挿入する
  - オーディオトラックは新規・既存どちらでも可
  - 同時に、ビンへの追加登録も可能
- RemoveJimakuPrefix
  - 選択したビデオトラック内のテキストイベントの接頭辞(声優名)を削除する
- SetJimakuColor
  - 選択したビデオトラック内のテキストイベントの文字色とアウトライン(色・幅)を指定したものに変更する

## 必要なパッケージ

VegasScriptHelper用に以下のNuGetパッケージを使用しています。
事前にパッケージの導入をよろしくお願い申し上げます。

- YamlDotNet
  - マスタデータYAMLファイルのアクセスに必要
- MarkDig
  - ShowTipsでのMarkdownファイル処理に使用

## VegasScriptDebugについて

VisualStudioでデバッグするためのコードですので、
他の環境で使用したときの動作保証はできません。

## VegasScriptPrescribedPatternについて

このスクリプトは、スクリプトのプロジェクトを作成するときのテンプレートを作るためのものです。
ビルドしても何も機能しません。

## VegasScriptHelperのインストール・デプロイに関して

デプロイ用に `deploy_dll_files.py` をご用意いたしましたので、こちらをご利用ください。

```bash
python deploy_files.py
```

もしくは、

```bash
python3 deploy_files.py
```

でデプロイできます。

使用できるオプションは以下の3種類。

大文字でも小文字でも対応

- -Y(--UPDATE_YAML)
  - YAMLファイルを強制上書きコピー
  - デプロイ先に存在していないときは自動的にコピー
- -M(--UPDATE_MARKDOWN)
  - Markdownファイルを強制上書きコピー
  - デプロイ先に存在していないときは自動的にコピー
- -V(--VARBOSE)
  - 詳細な内容の出力

## ライセンス

拡張機能集はMITライセンスを適応しております。
詳細は `LICENSE` ファイルを御覧ください。

本スクリプトでは、共通フォントとしてM PLUS 1フォント(SIL Open Font License版)を使用しています。

https://fonts.google.com/specimen/M+PLUS+1

ダイアログで使用しているアイコンは、CC0の「EverIcons」のものをベースとしております。

http://www.evericons.com/

## 免責事項

本拡張機能集に登場する商品名は各ステークホルダーが権利を所持しております。
このスクリプトでは、各エンジン・声優の利用条件を遵守いたします。

本拡張機能集内で使用しているエンジン名・声優名は、データのキーワードとして使用しており、権利を侵害する目的で使用していないことを誓います。

そのため、**本拡張機能集を使用しての各エンジン・声優の許諾範囲を超える動画を作らないよう、強くお願い致します。**

各音声合成エンジン・各声優については、それぞれの許諾範囲をご確認ください。

また、本拡張機能集を使用したことによるトラブル・問題が発生したとしても、
当方は全く責任を負いません。

### 各合成音声エンジンのライセンスリンク

#### AquesTalk

<https://www.a-quest.com/products/aquestalk.html>

#### ゆっくり音声（東方Project二次創作ガイドライン)

<https://touhou-project.news/guideline/>

#### A.I.VOICE

<https://aivoice.jp/>

#### VOICEROIDシリーズ

<https://www.ah-soft.com/voiceroid/>

#### VOICEPEAK

<https://www.ah-soft.com/voice/>

#### CeVIO CS

<https://cevio.jp/product/ccs/>

#### CeVIO AI

<https://cevio.jp/products_cevio_ai/>

#### VOICEVOX

<https://voicevox.hiroshiba.jp/>

## 謝辞

ゆっくり音声名については、以下のサイトを参考させて頂いております。


ありがとうございます。

- [ユウイナちゃんねるのブログ 東方ゆっくりボイス一覧](https://ameblo.jp/staffoz/entry-12701709291.html)
- [nicotalk & キャラ素材配布所 きつねゆっくり](http://www.nicotalk.com/charasozai_kt.html)
- [nicotalk & キャラ素材配布所 新きつねゆっくり](http://www.nicotalk.com/charasozai_sky.html)
- [東方MMDまとめ 東方Projectのキャラクター一覧と読み方](https://imimatome.com/touhoummd/kyara/638/)
