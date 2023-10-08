clean ()
{
    cd ..
    cd Informe
    rm -f *.aux *.lot *.lof *.log *.toc *.dvi *.ps *.bbl *.out *.synctex.gz *.fls *.fdb_latexmk *.nav *.snm *.vrb *.gz
    rm -r build *.pdf
    cd ..
    cd Presentacion 
    rm -f *.aux *.lot *.lof *.log *.toc *.dvi *.ps *.bbl *.out *.synctex.gz *.fls *.fdb_latexmk *.nav *.snm *.vrb *.gz
    rm -r build *.pdf
    cd ..
    cd MoogleServer
    rm -r bin obj
}
clean