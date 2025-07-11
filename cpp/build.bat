@echo off
echo Building C++ E-Commerce System...

REM Try to find and use g++
where g++ >nul 2>nul
if %errorlevel% == 0 (
    echo Found g++, building...
    g++ -std=c++17 -Wall -Wextra -pedantic -O2 -o ecommerce.exe *.cpp
    if %errorlevel% == 0 (
        echo Build successful! Run ecommerce.exe to start the application.
    ) else (
        echo Build failed with g++
    )
    goto :end
)

REM Try to find and use cl (Visual Studio)
where cl >nul 2>nul
if %errorlevel% == 0 (
    echo Found cl (Visual Studio), building...
    cl /std:c++17 /EHsc /W4 /O2 *.cpp /Fe:ecommerce.exe
    if %errorlevel% == 0 (
        echo Build successful! Run ecommerce.exe to start the application.
    ) else (
        echo Build failed with cl
    )
    goto :end
)

REM Try to find and use clang++
where clang++ >nul 2>nul
if %errorlevel% == 0 (
    echo Found clang++, building...
    clang++ -std=c++17 -Wall -Wextra -pedantic -O2 -o ecommerce.exe *.cpp
    if %errorlevel% == 0 (
        echo Build successful! Run ecommerce.exe to start the application.
    ) else (
        echo Build failed with clang++
    )
    goto :end
)

echo No C++ compiler found. Please install:
echo - MinGW/MSYS2 (for g++)
echo - Visual Studio (for cl)
echo - LLVM/Clang (for clang++)

:end
