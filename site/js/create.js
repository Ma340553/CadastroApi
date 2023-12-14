function createPessoa(){
const primeiroNome = document.getElementById("firstName").value;
const segundoNome = document.getElementById("middleName").value;
const ultimonome = document.getElementById("lastName").value;
const cpf= document.getElementById("cpf").value;

const data={
    primeiroNome:primeiroNome,
    nomeMeio: segundoNome,
    ultimoNome:ultimonome,
    cpf:cpf
}


fetch('https://localhost:7005/api/Pessoa/create',{

method: 'POST',
headers: {
    'Content-Type': 'application/json'
},
body: JSON.stringify(data)
}).then(response => {
    if(!response.ok){
        alert("Erro ao criar pessoa");
    }
    alert("pessoa criada com sucesso!");
    window.location.href = '../index.html';
})
}