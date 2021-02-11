@echo off

cd\
cd I:\OMEN\Assets\MapDir\working


echo Copying Files...
copy I:\OMEN\Assets\MapDir\working\omen_map-test_1.map I:\OMEN\Assets\MapDir\working


echo Converting map...


echo --------------QBSP--------------
I:\OMEN\Assets\Tools\quake-leveldesign-starterkit\tools\ericw-tools\bin\qbsp.exe -verbose omen_map-test_1

echo --------------VIS---------------
I:\OMEN\Assets\Tools\quake-leveldesign-starterkit\tools\ericw-tools\bin\vis.exe omen_map-test_1

copy omen_map-test_1.bsp I:\OMEN\Assets\Game\maps
copy omen_map-test_1.pts I:\OMEN\Assets\Game\maps
copy omen_map-test_1.lit I:\OMEN\Assets\Game\maps
pause
