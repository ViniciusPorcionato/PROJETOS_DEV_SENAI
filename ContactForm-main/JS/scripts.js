

    const urlLocal = "http://localhost:3000/http://localhost:3000/contatos";

        async function cadastrar(e) {
            e.preventDefault();

            const nome = document.getElementById('nome').value;
            const sobrenome = document.getElementById('sobrenome').value;
            const email = document.getElementById('emal').value;
            const pais = document.getElementById('pais').value;
            const ddd = document.getElementById('ddd').value;
            const telefone = document.getElementById('telefone').value;
            const cep = document.getElementById('cep').value;
            const rua = document.getElementById('rua').value;
            const numero = document.getElementById('numero').value;
            const complemento = document.getElementById('complemento').value;
            const bairro = document.getElementById('bairro').value;
            const cidade = document.getElementById('cidade').value;
            const uf = document.getElementById('UF').value;

            const objDados = { nome, sobrenome, email, pais, ddd, telefone, cep, rua, numero, complemento, bairro, cidade, uf }

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