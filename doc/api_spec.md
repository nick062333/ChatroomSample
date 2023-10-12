

# API Spec


## 目錄
<!-- TOC -->

- [API Spec](#api-spec)
    - [目錄](#%E7%9B%AE%E9%8C%84)
    - [版本異動紀錄](#%E7%89%88%E6%9C%AC%E7%95%B0%E5%8B%95%E7%B4%80%E9%8C%84)
    - [使用者建立](#%E4%BD%BF%E7%94%A8%E8%80%85%E5%BB%BA%E7%AB%8B)
        - [API Name:](#api-name)
    - [訊息傳送](#%E8%A8%8A%E6%81%AF%E5%82%B3%E9%80%81)

<!-- /TOC -->

## 版本異動紀錄

|-----------|---------|
| 2023/10/03|| 初版   |
|--------|---------|

## 1.使用者建立

## 2.訊息傳送

### 3.登入

####　3-1. Request URL
https://localhost:7057/api/Auth/login

####　3-2. curl

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

#### 3-3. Request body

```json
{
  "account": "nick001",
  "password": "123456"
}
```

#### 3-4. Response body

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