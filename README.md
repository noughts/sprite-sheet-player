# What

Animate で書きだしたスプライトシートを再生する Unity のコンポーネントです。
以下の設定でスプライトシートを書き出し、JSONとPNGをプロジェクトに追加して使いましょう。
- アルゴリズム: 基本
- データ形式: JSON-Array
- カット: OFF
- フレームをスタック: 任意

# How to install
1. Unity プロジェクトの Assets/ に package.json を作成します。
2. 以下を記述します。
```json
{
	  "dependencies": {
		    "sprite-sheet-player": "noughts/sprite-sheet-player"
	  }
}
```
3. Assets/ で npm install します。
