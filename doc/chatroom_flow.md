

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

alt 目前聊天室尚無訊息
    web ->> webapi:取得最新的前20筆訊息
    webapi -->> web:return 訊息
    web ->> indexDB:進行暫存
else 已有訊息
    web ->> webapi:取得所有最新訊息
    webapi -->> web:return 訊息
    web ->> indexDB:進行暫存
end

web ->> web:顯示訊息

```

# 三、發送訊息

```mermaid
sequenceDiagram

participant web as web(前端)
participant hub as SigalR(後端)
participant db as MS SQL
participant indexdb as IndexedDB(前端)

web ->> hub:發送訊息
hub ->> db:儲存訊息
db -->> hub:retrun
hub -->> web:retrun
web -->> web:將訊息顯示於聊天室
web ->> indexdb:訊息暫存
```