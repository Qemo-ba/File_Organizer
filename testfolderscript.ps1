$path = "C:\Users\qemal\TestFolder"
if (test-path $path) {
    Remove-Item -Recurse -Force $path
}
New-Item -ItemType Directory -Force -Path $path

"testdoku.pdf", "testbild.png", "testtabelle.xlsx", "testpowerpoint.pptx", "testvideo.mp4", "testother.py" | ForEach-Object { New-Item -ItemType File -Path $path -Name $_ }
