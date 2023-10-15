

# API Spec

## 一、目錄
<!-- TOC -->

- [API Spec](#api-spec)
  - [一、目錄](#一目錄)
  - [二、版本異動紀錄](#二版本異動紀錄)
  - [三、使用者](#三使用者)
    - [3-1. 登入](#3-1-登入)
      - [Request body](#request-body)
      - [Response body](#response-body)
    - [3-2. 驗證使用者Token](#3-2-驗證使用者token)
    - [3-3. 使用者列表](#3-3-使用者列表)
  - [四、 聊天室](#四-聊天室)
    - [4.1. 建立聊天室](#41-建立聊天室)
    - [4-2. 取得訊息列表](#4-2-取得訊息列表)

<!-- /TOC -->

## 二、版本異動紀錄

|異動時間| 異動說明   |
|--|--|
| 2023/10/15 | ...|

## 三、使用者

### 3-1. 登入
####　Request URL
https://localhost:7057/api/Auth/login

####　curl
 ```vim
curl -X 'POST' \
  'https://localhost:7057/api/Auth/login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "account": "nick001",
  "password": "123456"
}'
```

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

### 3-3. 使用者列表

## 四、 聊天室
### 4.1. 建立聊天室
### 4-2. 取得訊息列表