# Wir nutzen ausschliesslich das grosse SDK-Image, das alle C#-Werkzeuge (Compiler, Tester) enthält
FROM mcr.microsoft.com/dotnet/sdk:10.0

# Arbeitsverzeichnis festlegen
WORKDIR /src

RUN cd /src && mkdir /test-folder && touch /test-folder/test.txt /test-folder/bild.png /test-folder/video.mp4 /test-folder/document.pdf /test-folder/archive.zip /test-folder/presentation.pptx /test-folder/song.mp3 /test-folder/image.jpg /test-folder/script.py /test-folder/music.mp3 /test-folder/tabelle.xlsx

# Den kompletten Code in den Container kopieren
COPY  . /src

# Anstatt das Programm starr zu starten, öffnen wir eine interaktive Kommandozeile (bash)
ENTRYPOINT ["dotnet", "run", "--", "/test-folder"]
