show_slides() 
{
    cd ..
    cd Presentacion
    if [ !-f informe.pdf ]
    then
    pdflatex presentación.tex
    fi
    start presentación.pdf
}
show_slides