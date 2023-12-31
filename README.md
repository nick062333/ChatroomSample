# ChatroomSample 聊天室

## 專案目標
> 研究 .NET SignalR 即時聊天室
> 專案目標: 
> 規劃及開發一個留言板網站
> SignalR即時聊天室
> 前端使用vue
> 後端使用.net8
> 資料庫用Maria(Docker)

## 專案使用工具

1. 後端
   .NET8 Web API
   .NET8 SignalR
   MS SQL

2. 前端 
   Vue.js

## To Do List

- 上傳大頭貼
- 未讀訊息通知 (排在最前面)
- 改 MaridaDB

## 專案工作進度

|  日期   | 預計進度說明  | 實際完成項目 |
|  ----  | ----  | ----|
| 2023/10/03 | 1.簡易版留言版功能，目前可以開兩個瀏覽器同步對話 | 
| 2023/10/04  | 1.實作前台JWT登入驗證機制 | 1.實作前台JWT登入驗證機制 |
| 2023/10/05 | 1.SignalR JWT 驗證機制 <br> ~~2.SignalR Group設定與驗證~~  | 1.SignalR JWT 驗證機制 |
| 2023/10/06 | 1.後台-對話紀錄儲存至DB(預存程序) <br> 2.前台-重新進入聊天室時需顯示歷次對話紀錄  <br> 3.前台-登入資訊儲存至localStorage | 1.後台-對話紀錄儲存至DB(預存程序)<br> 3.前台-登入資訊儲存至localStorage |
| 2023/10/11 | 1.後台-訊息紀錄api <br> 2.使用者註冊 | 1.後台-訊息紀錄api <br> 2.使用者註冊 <br> 3.研究 fluentvalidation 套件後端驗證 <br> 4. 導入automapper 套件，用於model mapping <br> 5.實作訊息加密(ASE) and 密碼加密(sha256) + 方法單元測試 <br> 5.token資訊調整-增加使用者名稱 <br> 6.加入log機制(serilog)  |
| 2023/10/12 | 1.前台-訊息紀錄api介接顯示 <br> 2.前台-研究IndexedDB暫存前端訊息  | ... |
| 2023/10/13 | ~~1.DB改MariaDB~~ <br> ~~2.專案容器化~~  | ... |
| 2023/10/16 | 1.聊天室清單功能 |  1.聊天室清單功能 |
| 2023/10/16 | ~~群組功能測試~~<br> ~~2.Reids暫存列表資訊..~~ <br> ~~3.vue組件研究~~  | ... |
| 2023/10/17 | 研究 vue-cli webpack打包 | |
| 2023/10/18 | 研究 vue-cli webpack打包 | |
| 2023/10/19 | 研究 vue-cli webpack打包 <br> 撰寫webapi dockerfile | |
| 2023/10/20 | 1.vite打包 <br> 2.IIS架站 <br> 3.DB改MariaDB |  |