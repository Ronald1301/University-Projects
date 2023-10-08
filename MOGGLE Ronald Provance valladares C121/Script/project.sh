#! /bin/bash

echo "Elija una opción"
read a
if [ $a = "run" ]
then
bash run.sh
elif [ $a = "report" ]
then
bash report.sh
elif [ $a = "slides" ]
then
bash slides.sh
elif [ $a = "clean" ]
then
bash clean.sh
elif [ $a = "show_report" ]
then
bash show_report.sh
elif [ $a = "show_slides" ]
then
bash show_slides.sh
fi



