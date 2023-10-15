

# API Spec

## 一、目錄
<!-- TOC -->

- [API Spec](#api-spec)
  - [一、目錄](#一目錄)
  - [三、使用者](#三使用者)
    - [3-1. 登入](#3-1-登入)
      - [Request body](#request-body)
      - [Response body](#response-body)
    - [3-2. 驗證使用者Token](#3-2-驗證使用者token)
      - [Request URL](#request-url)
      - [Request body](#request-body-1)
      - [Response body](#response-body-1)
    - [3-3. 使用者列表](#3-3-使用者列表)
      - [Request URL](#request-url-1)
      - [Request body](#request-body-2)
      - [Response body](#response-body-2)
  - [四、 聊天室](#四-聊天室)
    - [4.1. 建立聊天室](#41-建立聊天室)
      - [Request URL](#request-url-2)
      - [Request body](#request-body-3)
      - [Response body](#response-body-3)
    - [4-2. 取得聊天室列表](#4-2-取得聊天室列表)
      - [Request URL](#request-url-3)
      - [Request body](#request-body-4)
      - [Response body](#response-body-4)

<!-- /TOC -->
| 2023/10/15 | ...|

## 三、使用者

### 3-1. 登入
####　Request URL
https://localhost:7057/api/Auth/login

#### Request body

|參數名稱|參數型態|說明|
|-|-|-|
|account|string|帳號|
|password|string|密碼|
```json
{
  "account": "nick001",
  "password": "123456"
}
```

#### Response body
|參數名稱|參數型態|說明|
|-|-|-|
|chatroomStatusCode|string||
|description|string||
|data|string||
```json
{
  "chatroomStatusCode": 200,
  "description": "",
  "data": {
    "token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTmljayIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMyIsInN1YiI6Ik5pY2siLCJqdGkiOiI4YWY5MzE2Ny01NTFiLTQ2MWUtYTM0My04NWRiNjE0ZGJkMjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsiQWRtaW4iLCJVc2VycyJdLCJleHAiOjE2OTcwODIwODQsImlzcyI6Ikp3dEF1dGhEZW1vIn0.Jo_-itJ-r0s-h6HV-rF2wxMQCAJ0j_XMDuhBIkixdhs",
    "userName": "Nick"
  }
}
```

### 3-2. 驗證使用者Token
#### Request URL
#### Request body
#### Response body


### 3-3. 使用者列表
#### Request URL
#### Request body
#### Response body

## 四、 聊天室

### 4.1. 建立聊天室
#### Request URL
#### Request body
#### Response body

### 4-2. 取得聊天室列表
#### Request URL
Method:GET
https://localhost:7057/api/Chat

#### Request body
無


#### Response body
|參數名稱|參數型態|說明|
|-|-|-|
|chatroomStatusCode|string|狀態|
|description|string|狀態說明|
|data|**ChatroomModel**|聊天室列表資訊|

**ChatroomModel**
|參數名稱|參數型態|說明|
|-|-|-|
|ChatroomId|string|聊天室代碼|
|UserId|string|使用者代碼|
|UserName|string|使用者名稱|
|LastLoginTime|string|最後登入時間|


```json
{
    "ChatroomStatusCode": 200,
    "Description": "",
    "Data": [
        {
            "ChatroomId": "46be0312-c43a-451d-8489-45f426bdba54",
            "UserId": "9",
            "UserName": "Andy",
            "LastLoginTime": "0001-01-01T00:00:00"
        },
        {
            "ChatroomId": "46be0312-c43a-451d-8489-45f426bdba54",
            "UserId": "10",
            "UserName": "Nick",
            "LastLoginTime": "0001-01-01T00:00:00"
        }
    ]
}
```