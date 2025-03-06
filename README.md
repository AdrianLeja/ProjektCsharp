[szablon_schronisko (3).pdf](https://github.com/user-attachments/files/19109961/szablon_schronisko.3.pdf)


\documentclass[12pt,a4paper]{report}

\usepackage[utf8]{inputenc}
\usepackage[T1]{fontenc}
\usepackage[polish]{babel}

\usepackage{geometry}
\geometry{margin=1in}

\usepackage{fancyhdr}
\usepackage{titlesec}
\usepackage{hyperref}
\usepackage{float}
\usepackage{listings}
\usepackage{graphicx}
\usepackage{microtype}


\titleformat{\chapter}[hang]{\bfseries\Huge}{\thechapter.}{0.5em}{}
\titleformat{\section}[hang]{\bfseries\Large}{\thesection}{0.5em}{}
\titleformat{\subsection}[hang]{\bfseries\large}{\thesubsection}{0.5em}{}

\begin{document}

% ------------------------------ STRONA TYTUŁOWA ------------------------------
\begin{titlepage}
    \centering
    \vspace*{-2cm}
    \includegraphics[width=0.4\linewidth]{logoWSIiZ.PNG}\\[1cm]
    {\large KOLEGIUM INFORMATYKI STOSOWANEJ\\}
    \vspace{1cm}
    {\large Kierunek: INFORMATYKA\\}
    \vspace{0.5cm}
    {\large Specjalność: Programowanie\\}
    \vspace{3cm}
    {\LARGE \textbf{System zarządzania schroniskiem dla zwierząt}}\\
    \vspace{2cm}
    {\large Adrian Leja\\Nr albumu: w69985\\}
    \vspace{2cm}
    {\large Prowadzący: mgr inż. Ewa Żesławska\\}
    \vspace{1cm}
    \textbf{Praca projektowa\\ Programowanie obiektowe \\ C\#}
    \vfill
    {Rzeszów 2025}
\end{titlepage}

% ------------------------------ SPIS TREŚCI ------------------------------
\tableofcontents
\newpage

% ------------------------------ WSTĘP ------------------------------
\chapter*{Wstęp}
\addcontentsline{toc}{chapter}{Wstęp}
Na co dzień wiele osób angażuje się w działalność mającą na celu poprawę życia zwierząt w schroniskach. Jednakże wciąż brakuje w pełni zintegrowanych narzędzi, które usprawniałyby zarówno codzienną obsługę podopiecznych, jak i administrowanie wszystkimi procesami wewnątrz placówki. W efekcie wiele czynności – od rejestrowania nowo przyjętych zwierząt po koordynację wizyt weterynaryjnych – wykonywanych jest w sposób rozproszony i czasochłonny. Dodatkowo utrudnione bywa gromadzenie spójnych informacji o stanie zdrowia i historii adopcji, co może przekładać się na obniżenie jakości opieki.

Praca koncentruje się na stworzeniu systemu, który zintegruje te wszystkie działania, pozwalając na efektywne zarządzanie adopcjami, lokalizacją zwierząt w schronisku, danymi o pracownikach oraz monitorowaniem kluczowych parametrów związanych z kondycją zwierząt. Dzięki temu zarówno pracownicy, jak i wolontariusze zyskają prosty w obsłudze interfejs, który usprawni proces adopcji oraz ograniczy powielanie zadań administracyjnych.

Wprowadzenie takiej aplikacji może znacząco odciążyć personel w codziennej pracy, a przy okazji przyczynić się do poprawy warunków życia zwierząt – pracownicy będą mogli skupić się przede wszystkim na ich dobrostanie, zamiast tracić czas na zbędną biurokrację. Co więcej, nowoczesne rozwiązania technologiczne (takie jak ASP.NET Core czy SQL Server) zapewniają bezpieczeństwo i skalowalność, dzięki czemu system będzie mógł być rozwijany wraz z rosnącymi potrzebami schroniska. Krótkoterminowym celem projektu jest przyśpieszenie i usprawnienie obsługi adopcji, natomiast długofalowo – stworzenie solidnych podstaw do jeszcze bardziej zaawansowanego zarządzania i analizy danych w przyszłości.








\newpage

% ------------------------------ ROZDZIAŁ 1 ------------------------------
\chapter{Opis założeń projektu}
\section{Cele projektu}
Celem projektu jest stworzenie systemu zarządzania schroniskiem dla zwierząt, który umożliwi:
\begin{itemize}
    \item sprawne zarządzanie adopcjami zwierząt,
    \item monitorowanie lokalizacji zwierząt w schronisku,
    \item zarządzanie informacjami o pracownikach i użytkownikach,
    \item zwiększenie dostępności danych oraz ich przejrzystości.
\end{itemize}
Problemem, który system rozwiązuje, jest brak zintegrowanego narzędzia do kompleksowego zarządzania procesami w schroniskach. Projekt przewiduje stworzenie aplikacji internetowej opartej na nowoczesnych technologiach, takich jak ASP.NET Core i SQL Server.

\section{Wymagania funkcjonalne i niefunkcjonalne}
\subsection{Wymagania funkcjonalne}
\begin{itemize}
    \item Zarządzanie procesem adopcji zwierząt.
    \item Możliwość dodawania, edycji i usuwania informacji o zwierzętach.
    \item Wyszukiwanie zwierząt według określonych kryteriów (gatunek, rasa, wiek).
    \item Zarządzanie użytkownikami oraz ich dostępem do systemu.
\end{itemize}

\subsection{Wymagania niefunkcjonalne}
\begin{itemize}
    \item Wysoka wydajność aplikacji.
    \item Intuicyjny interfejs użytkownika.
    \item Zgodność z przeglądarkami internetowymi.
    \item Zabezpieczenie danych użytkowników i zwierząt.
\end{itemize}

\newpage

% ------------------------------ ROZDZIAŁ 2 ------------------------------
\chapter{Opis struktury projektu}
Projekt został stworzony z wykorzystaniem następujących technologii:
\begin{itemize}
    \item \textbf{Backend:} ASP.NET Core (język C\#), 
    \item \textbf{Frontend:} HTML, CSS,
    \item \textbf{Baza danych:} SQL Server.
\end{itemize}
Struktura projektu obejmuje modele, kontrolery oraz widoki w standardzie MVC (Model-View-Controller). Dodatkowo zastosowano repozytorium GitHub do zarządzania wersjami.

\newpage

% ------------------------------ ROZDZIAŁ 3 ------------------------------
\chapter{Harmonogram realizacji projektu}
Harmonogram projektu przedstawiono w formie diagramu Gantta (rysunek \ref{fig:diagram-gantta}).  
Realizacja prac została podzielona na kilka głównych etapów:

\begin{enumerate}
    \item \textbf{Analiza wymagań} (5 dni),
    \item \textbf{Projektowanie struktury bazy danych} (1 tydzień),
    \item \textbf{Implementacja funkcjonalności backendu} (1 tydzień),
    \item \textbf{Tworzenie interfejsu użytkownika} (1 tydzień),
    \item \textbf{Testy i wdrożenie} (1 tydzień).
\end{enumerate}

\begin{figure}[H]
    \centering
    \includegraphics[width=0.8\linewidth]{image.png}
    \caption{Diagram Gantta}
    \label{fig:diagram-gantta}
\end{figure}

\noindent
\textbf{Repozytorium i system kontroli wersji.}\\
Wszystkie pliki źródłowe i dokumentacja zostały zgromadzone w publicznym repozytorium na platformie GitHub:  
\url{https://github.com/AdrianLeja/ProjektCsharp}  

Do zarządzania kodem wykorzystano system kontroli wersji Git, co pozwoliło na:
\begin{itemize}
    \item bieżące śledzenie historii zmian (commitów),
    \item równoległe prowadzenie prac w osobnych gałęziach (branchach),
    \item rozwiązywanie konfliktów i scalanie różnych wersji,
    \item łatwe przywracanie poprzednich wersji w razie potrzeby.
\end{itemize}

\newpage

% ------------------------------ ROZDZIAŁ 4 ------------------------------
\chapter{Prezentacja warstwy użytkowej projektu}
Aplikacja zawiera następujące funkcjonalności dostępne w interfejsie użytkownika:
\begin{itemize}
    \item Strona główna z podstawowymi informacjami o schronisku.
\end{itemize}

\begin{figure}[H]
    \centering
    \includegraphics[width=0.8\linewidth]{image.png}
    \caption{Strona Główna}
    \label{fig:strona-glowna}
\end{figure}

\begin{itemize}
    \item Moduł zarządzania adopcjami.
\end{itemize}

\begin{figure}[H]
    \centering
    \includegraphics[width=0.8\linewidth]{image.png}
    \caption{Adopcje}
    \label{fig:adopcje}
\end{figure}

\begin{itemize}
    \item Wyszukiwarka zwierząt.
\end{itemize}

\begin{figure}[H]
    \centering
    \includegraphics[width=0.8\linewidth]{image.png}
    \caption{Zwierzęta}
    \label{fig:zwierzeta}
\end{figure}

\begin{itemize}
    \item Panel administratora umożliwiający zarządzanie danymi.
\end{itemize}

\begin{figure}[H]
    \centering
    \includegraphics[width=0.8\linewidth]{image.png}
    \caption{Pracownicy}
    \label{fig:pracownicy}
\end{figure}

\newpage

% ------------------------------ ROZDZIAŁ 5 ------------------------------
\chapter{Podsumowanie}
W ramach projektu stworzono aplikację, która znacząco usprawnia zarządzanie schroniskiem dla zwierząt, pomagając w organizacji adopcji, monitorowaniu lokalizacji i danych zwierząt oraz zarządzaniu pracownikami. System działa na bazie ASP.NET Core używając wzorca MVC, co zapewnia łatwą skalowalność i modyfikacje w przyszłości. Do przechowywania danych wykorzystano SQL Server, co pozwala na szybkie i bezpieczne zarządzanie informacjami. Projekt zawiera intuicyjny panel administratora, który ułatwia zarządzanie danymi, w tym pracownikami. System jest zaprojektowany z myślą o bezpieczeństwie, stabilności i łatwej rozbudowie, co sprawdzi się zarówno w małych, jak i dużych schroniskach. Zastosowane rozwiązania umożliwiają różne poziomy uprawnień użytkowników, co pozwala na pełną kontrolę nad danymi. Dzięki aplikacji pracownicy schroniska mogą szybko dodawać nowe zwierzęta, edytować ich dane i śledzić proces adopcji. Interfejs jest przyjazny, a system działa na urządzeniach mobilnych, dzięki zastosowaniu technologii RWD. Planowane są również funkcje umożliwiające analizowanie danych z adopcji oraz kosztów utrzymania schroniska. Podsumowując, stworzony system jest solidną bazą dla zarządzania schroniskiem, przyczyniając się do efektywniejszego funkcjonowania i poprawy jakości życia zwierząt. Projekt ma potencjał do dalszego rozwoju oraz wspierania społeczności przy poszukiwaniach domów dla zwierząt. przez 6 sekund(y)
W ramach projektu powstała aplikacja, która w jednym miejscu gromadzi wszystkie najważniejsze funkcje niezbędne do sprawnego zarządzania schroniskiem dla zwierząt – od dodawania nowych podopiecznych i edycji ich danych, przez ustalanie lokalizacji w budynku, aż po pełną obsługę adopcji. System został zaprojektowany w architekturze MVC przy użyciu ASP.NET Core oraz bazy danych SQL Server, co gwarantuje jego stabilne działanie oraz łatwe wprowadzanie zmian w przyszłości.

Dzięki modułowi administracyjnemu pracownicy mogą szybko zarejestrować nowe zwierzę i aktualizować informacje o nim, a różne poziomy uprawnień użytkowników pozwalają na utrzymanie bezpieczeństwa danych. Intuicyjna nawigacja, przyjazny interfejs i zastosowanie RWD (Responsive Web Design) sprawiają, że system działa równie dobrze na urządzeniach mobilnych, co jest szczególnie przydatne w trakcie codziennej pracy czy przy adopcjach w terenie.

W przyszłości planowane jest rozszerzenie projektu o bardziej rozbudowane raporty i analizy statystyczne (np. koszty utrzymania zwierząt, częstotliwość adopcji), co pomoże jeszcze lepiej planować i gospodarować zasobami schroniska. Podsumowując, rozwiązanie to realnie wpływa na poprawę funkcjonowania placówki i zwiększa komfort zarówno zwierząt, jak i osób zainteresowanych adopcją.

\newpage

% ------------------------------ BIBLIOGRAFIA ------------------------------
\addcontentsline{toc}{chapter}{Bibliografia}
\begin{thebibliography}{9}

\bibitem{aspnetcore}
Microsoft Docs,  
\emph{ASP.NET Core documentation},  
[Online; dostęp 28 stycznia 2025],  
\url{https://learn.microsoft.com/aspnet/core/}


\end{thebibliography}

\end{document}
