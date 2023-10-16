

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
    const situacao = geraSituacao(imc);

    const pessoa = {
        nome : nome,
        altura : altura,
        peso : peso,
        imc : imc,
        situacao : situacao
    }

    console.log(pessoa);
}


function calcularIMC(peso, altura) {
    return peso / Math.pow(altura, 2);
}

function geraSituacao(imc) {
    if (imc < 18.5) {
        return "Magreza Severa";
    }
    else if (imc <= 24.99 ) {
        return "Peso Normal";
    }
    else if (imc <= 29.99 ) {
        return "Acima do Peso";
    }
    else if (imc <= 34.99 ) {
        return "Obesidade I";
    }
    else if (imc <= 39.99 ) {
        return "Obesidade II";
    }
    else{
        return "Cuidado !!"
    }
}//fim da função