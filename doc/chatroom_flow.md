

# 目錄

<!-- TOC -->

- [目錄](#%E7%9B%AE%E9%8C%84)
- [一、建立聊天室](#%E4%B8%80%E5%BB%BA%E7%AB%8B%E8%81%8A%E5%A4%A9%E5%AE%A4)
- [二、進入聊天室](#%E4%BA%8C%E9%80%B2%E5%85%A5%E8%81%8A%E5%A4%A9%E5%AE%A4)
- [三、載入舊訊息](#%E4%B8%89%E8%BC%89%E5%85%A5%E8%88%8A%E8%A8%8A%E6%81%AF)

<!-- /TOC -->
# 一、建立聊天室

```mermaid
sequenceDiagram

participant web as web(前端) 
participant webapi
participant db as MS SQL


Note right of web: 點擊聊天室

web ->> webapi:取得聊天室資訊
alt 聊天室已存在
    webapi ->> db:取得聊天室資訊
else 聊天室不存在
    webapi ->> webapi:產生聊天室
    webapi ->> db:新增聊天室資訊
end
webapi-->>web: return 聊天室資訊

```

# 二、進入聊天室

```mermaid
sequenceDiagram

participant web as web(前端)

participant indexDB as IndexedDB(前端)

web ->> indexDB:取得聊天室暫存資訊

web ->> web:取得頁面中訊息最後一筆與最新一筆的id

opt 目前畫面尚無訊息
    web ->> webapi:取得最新的20筆訊息
    webapi -->> web:return
    web ->> indexDB:進行暫存
end

```

# 三、載入訊息

