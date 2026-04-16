# (C# 코딩) 파일 비교툴
## 개요
- C# 프로그래밍 학습
- 1줄 소개: 두 폴더의 파일들을 비교해서 상호 복사하는 툴을 만들기 
- 핵심기능: UI 구성에 사용한 다양한 컨트롤과 FolderBrowserDialog와 같은 클래스 사용을 통한 파일 복사 프로그램
- 화면구성: Label, Textbox, Button, SplitContainer, ListView, Panel
- 사용한 플랫폼: 
	- C#, .NET Windows Forms, Visual Studio, GitHub
- 사용한 컨트롤:
	- Label, TextBox, Button, SplitContainer, ListView
- 사용한 기술과 구현한 기능:
	- Visual Studio를 이용하여 UI 디자인
	- ListView 컨트롤을 이용한 파일 목록 표시 기능 구현
	- SplitContainer를 이용하여 화면 분할 기능 구현
	- FolderBrowserDialog 클래스를 사용한 윈도우 파일 브라우저 사용
	- 

## 실행 화면 (과제1)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot1.png)
![실행화면](img/screenshot1-1.png)

- 구현한 내용(위 그림 참조)
	- UI 구성을 위한 GUI 설계 및 컨트롤 배치
	- 컨트롤에서 기본적으로 제공하는 기능 구현
	- 각 컨트롤의 Anchor 속성을 이용한 UX 기능 구현 완료

## 실행 화면 (과제2)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-2.png)
- 구현한 내용 (위 그림 참조)
	- 패스워드 입력 내용 숨기기 : UseSystemPasswordChar 속성 이용
	- Placeholder 메시지를 표시할 때는 UseSystemPasswordChar 없애기

## 실행 화면 (과제3)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-3.png)
- 구현한 내용 (위 그림 참조)
	- UI 구성 : Label(앱 이름 표시), TextBox 2개(아이디, 패스워드) 
	- Placeholder 표시 : 아이디와 패스워드 입력 힌트를 입력창 안에 회색으로 표시
	- 로그인 버튼 : 아이디와 패스워드가 모두 맞아야 로그인 허용

## 실행 화면 (과제4)
- 코드의 실행 스크린샷과 구현 내용 설명
![실행화면](img/screenshot-4.png)
- 구현한 내용 (위 그림 참조)
	- 패스워드 입력 내용 숨기기 : UseSystemPasswordChar 속성 이용
	- Placeholder 메시지를 표시할 때는 UseSystemPasswordChar 없애기