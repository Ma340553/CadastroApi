document.addEventListener('DOMContentLoaded', function(){
 
    const pessoaList= document.getElementById('pessoa-lista');
 
    function renderTable(data){/*função para aparecer na tela */
        pessoaList.innerHTML='';
 
        data.forEach(pessoa =>{
            const row = document.createElement('tr');
            row.innerHTML= `
<td>${pessoa.pessoaid}</td>
<td>${pessoa.primeironome}</td>
<td>${pessoa.nomemeio}</td>
<td>${pessoa.ultimonome}</td>
<td>${pessoa.cpf}</td>
<td>
<button>Editar</button>
<button>Excluir</button>
</td>
            `;
            pessoaList.appendChild(row);
        })
    }
 
    function feachPessoas(){
        fetch("https://localhost:7005/api/Pessoa/getall")
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error('Erro ao buscar dados da API'))
    }
    feachPessoas();
 
})

    function abrirTelacreate(){
    window.location.href = 'pages/create.html';
}