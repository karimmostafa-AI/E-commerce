@echo off
echo Building C++ E-Commerce System...

where g++ >nul 2>nul
if %errorlevel% == 0 (
    echo Found g++
    g++ -std=c++17 -Wall -Wextra -pedantic -O2 -o ecommerce.exe *.cpp
    if %errorlevel% == 0 (
        echo Build successful! Run ecommerce.exe to start the application.
    ) else (
        echo Build failed with g++
    )
    goto :end
)

where cl >nul 2>nul
if %errorlevel% == 0 (
    echo Found cl Visual Studio
    cl /std:c++17 /EHsc /W4 /O2 *.cpp /Fe:ecommerce.exe
    if %errorlevel% == 0 (
        echo Build successful! Run ecommerce.exe to start the application.
    ) else (
        echo Build failed with cl
    )
    goto :end
)

echo No C++ compiler found. Please install MinGW/MSYS2 or Visual Studio.

:end
