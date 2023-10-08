show_report() 
{
    cd ..
    cd Informe
    if [ !-f informe.pdf ]
    then
    pdflatex informe.tex
    fi
    start informe.pdf

}
show_report