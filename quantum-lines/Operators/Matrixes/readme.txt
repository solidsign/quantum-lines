это директория для сохранения .dat файлов матриц операторов

надо будет сделать operatorsHolder с таким смыслом:

operatorsDictionary: [
    {
        id: Hadamard,
        filename: hadamard.dat
    },
    {
        id: Not,
        filename: not.dat
    }
] 

мб и больше полей надо будет, например путь до картинки для оператора