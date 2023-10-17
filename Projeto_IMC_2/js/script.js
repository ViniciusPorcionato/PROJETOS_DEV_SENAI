//lista global
const listaPessoas = [];

function calcular(e) {
    //interrompe/captura o evento disparado
    e.preventDefault();

    console.log("Calcular IMC");

    let nome = document.getElementById("nome").value.trim();//limpa a string
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    //verifica se há algum campo sem preencher
    if (isNaN(altura) || isNaN(peso) || nome.length < 2) {
        alert('É necessário preencher todos os campos')
        return;
    }

    const imc = calcularIMC(peso, altura)
    const txtsituacao = geraSituacao(imc);
    let now = new Date();

    //object short sintaxe
    const pessoa = {
        nome,
        //propriedade : valor
        altura: altura,
        peso,
        imc,
        situacao: txtsituacao,
        dataCadastro: `${now.getDate()}/${now.getMonth() + 1}/${now.getFullYear()} ${now.getHours()}:${now.getMinutes()}`,
    }

    listaPessoas.push(pessoa);

    exibirDados();

}


function calcularIMC(peso, altura) {
    return peso / Math.pow(altura, 2);
}

function geraSituacao(imc) {
    if (imc < 18.5) {
        return "Magreza Severa";
    }
    else if (imc <= 24.99) {
        return "Peso Normal";
    }
    else if (imc <= 29.99) {
        return "Acima do Peso";
    }
    else if (imc <= 34.99) {
        return "Obesidade I";
    }
    else if (imc <= 39.99) {
        return "Obesidade II";
    }
    else {
        return "Cuidado !!"
    }
}//fim da função

function exibirDados() {

    console.log(listaPessoas);
    let linhas = "";

    listaPessoas.forEach(function (oPessoa) {
        //linhas de tabela
        linhas += `
    <tr>
         <td data-cell="nome">${oPessoa.nome}</td>
         <td data-cell="altura">${oPessoa.altura}</td>
         <td data-cell="peso">${oPessoa.peso}</td>
         <td data-cell="valor do IMC">${oPessoa.imc}</td>
         <td data-cell="classificação do IMC">${oPessoa.situacao}</td>
         <td data-cell="data de cadastro">${oPessoa.dataCadastro}</td>
    </tr>
    `;
    });

    //inserir as linhas de tabela no html
    document.getElementById("corpo-tabela").innerHTML = linhas;
}