@echo off

cd\
cd I:\OMEN\Assets\MapDir\working


echo Copying Files...
copy I:\OMEN\Assets\MapDir\id1\maps\testbed.map I:\OMEN\Assets\MapDir\working


echo Converting map...


echo --------------QBSP--------------
I:\OMEN\Assets\Tools\quake-leveldesign-starterkit\tools\ericw-tools\bin\qbsp.exe testbed

echo --------------VIS---------------
I:\OMEN\Assets\Tools\quake-leveldesign-starterkit\tools\ericw-tools\bin\vis.exe testbed

echo -------------LIGHT--------------
I:\OMEN\Assets\Tools\quake-leveldesign-starterkit\tools\ericw-tools\bin\light.exe testbed

copy testbed.bsp I:\OMEN\Assets\MapDir\id1\maps
copy testbed.pts I:\OMEN\Assets\MapDir\id1\maps
copy testbed.lit I:\OMEN\Assets\MapDir\id1\maps
pause
cd\
cd I:\OMEN\Assets\Tools\quake-leveldesign-starterkit
quakespasm-spiked-win64  +map testbed
