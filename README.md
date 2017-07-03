# HiDL
빠르며 안정적인 히읍읍 다운로더, 뷰어.

개요
--------
VB로 구현한 히읍읍 다운로더(및 스크롤 형식의 뷰어) 구현체입니다.

기존의 수많은 타 구현체에서는 다운로드 작업 시에 '1.jpg'부터 마지막 이미지 파일까지 순차로 다운로드 받도록 구현되어 있으나, 서버의 파일명 순번이 내림차순으로 정렬되어 있지 않은 경우와, 확장명이 'png' 등으로 'jpg'와는 다른 경우가 간혹 있으므로 이는 옳은 방법이 아닙니다. 

또한, 이미지 파일의 확장명과 MIMETYPE이 서로 일치하지 않는 경우도 간혹 존재합니다. 때문에 기존의 일반적인 방법으로 파일을 다운로드 받아 사용한다면 모바일이나 일부 브라우저에서 호환성이 떨어지게 됩니다. 

따라서, 이 문제를 해결하기 위해 본 다운로더 구현체에서는 이미지를 다운로드 한 뒤 파일의 MIMETYPE을 체크하여 올바른 확장명으로 변경하도록 했습니다. 


기능
--------
HiDL은 세 가지의 기능이 두 부분으로 나뉘어 있습니다.

 - 스크롤 뷰어.
   - 사용자가 소지한 이미지를 상-하 스크롤 방식(웹툰 형식)으로 감상하세요.
 - HiDL
   - HiDownloader
     - 원하는 갤러리를 다운로드 받으세요. 정말 빠르며, MIMETYPE에 따라 자동으로 확장명을 수정하기에, 기기별 호환성에 구애받지 않습니다. 
   - HiViewer
     - 다운로드 받은 갤러리를 상-하 스크롤 방식(웹툰 형식)으로 감상할 수 있습니다.

이 모든 동작은 사용자가 신경 쓸 새 없이 모두 한번에, 자동으로 처리됩니다. 
