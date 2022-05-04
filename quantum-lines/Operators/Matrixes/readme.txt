это директория для сохранения .dat файлов матриц операторов
можно будет потом сделать json с таким смыслом:
{
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
} 

и с него подгружать в operatorsHolder

мб в json'е и больше полей надо будет, например путь до картинки для оператора

мб забьем на это и просто вхардкодим