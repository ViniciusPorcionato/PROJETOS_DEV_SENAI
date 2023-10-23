

    const urlLocal = "http://localhost:3000/http://localhost:3000/contatos";

        async function cadastrar(e) {
            e.preventDefault();

            const nome = document.getElementById('nome').value;
            const sobrenome = document.getElementById('sobrenome').value;
            const telefone = document.getElementById('telefone').value;
            const cep = document.getElementById('cep').value;
            const endereco = document.getElementById('endereco').value;
            const numero = document.getElementById('numero').value;
            const bairro = document.getElementById('bairro').value;
            const cidade = document.getElementById('cidade').value;
            const estado = document.getElementById('estado').value;

            const objDados = { nome, telefone, cep, endereco, numero, bairro, cidade, estado }

            try {

                const promise = await fetch(urlLocal, {
                    //transforma um objeto em JSON
                    body: JSON.stringify(objDados),
                    headers: { "Content-Type": "application/json" },
                    method: "post"
                });

                const retorno = promise.json();//pega o retorno da api

                console.log(retorno);

            } catch (error) {
                alert("Deu ruim" + error)
            }
        }