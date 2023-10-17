# ChatroomDB

## 一、Chatroom 聊天室

| 欄位名稱     | 欄位類型         | 索引 | 允許null | 預設值 | 說明                             |
| ------------ | ---------------- | ---- | -------- | ------ | -------------------------------- |
| Id           | uniqueidentifier | PK   |          |        | 聊天室代碼                       |
| ChatroomType | tinyint          |      |          |        | 聊天室類型 1:一對一 <br>2:一對多 |
| CreateTime   | datetime         |      |          |        | 建立時間                         |

## 二、ChatroomMember 聊天室成員
| 欄位名稱   | 欄位類型         | 索引 | 允許null | 預設值 | 說明       |
| ---------- | ---------------- | ---- | -------- | ------ | ---------- |
| UserId     | bigint           | PK   |          |        | 使用者代碼 |
| ChatroomId | uniqueidentifier | PK   |          |        | 聊天室代碼 |
| EntryTime  | EntryTime        |      |          |        | 入場時間   |

## 三、MessageLog 聊天訊息
| 欄位名稱   | 欄位類型         | 索引 | 允許null | 預設值 | 說明                   |
| ---------- | ---------------- | ---- | -------- | ------ | ---------------------- |
| Id         | bigint           | PK DESC   |          |        | 使用者代碼             |
| GroupId    | uniqueidentifier |      |          |        | 聊天室代碼             |
| Status     | tinyint          |      |          |        | 訊息狀態 1:正常 0:刪除 |
| Message    | varchar(MAX)     |      |          |        | 訊息                   |
| SendUserId | bigint           |      |          |        | 發送者-使用者代碼      |
| SendTime   | datetime         |      |          |        | 發送時間               |

## 四、User 使用者

| 欄位名稱      | 欄位類型     | 索引 | 允許null | 預設值 | 說明                   |
| ------------- | ------------ | ---- | -------- | ------ | ---------------------- |
| Id            | bigint       | PK   |          |        | 使用者代碼             |
| Account       | varchar(20)  |      |          |        | 聊天室代碼             |
| Password      | char(64)     |      |          |        | 訊息狀態 1:正常 0:刪除 |
| UserName      | nvarchar(20) |      |          |        | 訊息                   |
| CreateTime    | datetime     |      |          |        | 發送者-使用者代碼      |
| LastLoginTime | datetime     |      | Y        |        | 最後登入時間           |