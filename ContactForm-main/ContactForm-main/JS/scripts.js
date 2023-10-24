

    const urlLocal = "http://localhost:3000/contatos";

        async function cadastrar(e) {
            e.preventDefault();

            const nome = document.getElementById('nome').value;
            const sobrenome = document.getElementById('sobrenome').value;
            const email = document.getElementById('email').value;
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
            const anotacoes = document.getElementById('anotacoes').value;

            const objDados = { nome, sobrenome, email, pais, ddd, telefone, cep, rua, numero, complemento, bairro, cidade, uf, anotacoes }

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


        async function chamaApi() {

            const cep = document.getElementById("cep").value;
            const url = `https://viacep.com.br/ws/${cep}/json/`;

            try {//resolvida ou fullfiled
                const promise = await fetch(url);
                const endereco = await promise.json();

                exibeEndereco(endereco);

                console.log(endereco)
                //document.getElementById("not-found").innerText = "";

            }
            catch (error) {
                //rejeitada 
                console.log("Deu ruim na api");

                //informa o Usuario
                document.getElementById("not-found").innerText = "Cep Invalido!";
                apagaEndereco();
            }
        }

        //preencher o html com os dados do json
        function exibeEndereco(endereco) {
            document.getElementById("rua").value = endereco.logradouro;
            document.getElementById("bairro").value = endereco.bairro;
            document.getElementById("cidade").value = endereco.localidade;
            document.getElementById("UF").value = endereco.uf;
        }

        function apagaEndereco() {
            document.getElementById("rua").value = "";
            document.getElementById("bairro").value = "";
            document.getElementById("cidade").value = "";
            document.getElementById("UF").value = "";
        }