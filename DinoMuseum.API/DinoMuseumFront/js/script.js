let todosOsDinos = [];
let todasAsEras = [];
const API_URL = "http://localhost:5180/api";

async function carregarDados() {
    try {
        const [resDinos, resEras] = await Promise.all([
            fetch(`${API_URL}/Dinossauro`),
            fetch(`${API_URL}/Era`)
        ]);
        todosOsDinos = await resDinos.json();
        todasAsEras = await resEras.json();
        
        exibirEras(todasAsEras);
        exibirDinos(todosOsDinos);
        preencherSelectEras(todasAsEras);
    } catch (e) { 
        console.error("Erro ao carregar dados da API:", e); 
    }
}


function exibirEras(eras) {
    const containerEras = document.getElementById('menu-eras');
    if (!containerEras) return;

    
    let botoesHtml = `<button onclick="filtrarPorEra('todas')">Todas as Eras</button>`;
    botoesHtml += eras.map(e => `<button onclick="filtrarPorEra('${e.id}')">${e.nome}</button>`).join('');
    
   
    containerEras.innerHTML = botoesHtml;
}

function preencherSelectEras(eras) {
    const select = document.getElementById('eraIdSelect');
    if (select) {
        select.innerHTML = eras.map(e => `<option value="${e.id}">${e.nome}</option>`).join('');
    }
}

function exibirDinos(lista) {
    const container = document.getElementById('lista-dinos');
    if (!container) return;

    container.innerHTML = lista.map(d => {
        const img = d.imagemUrl || 'https://via.placeholder.com/300x180';
       
        const desc = (d.descricao || "").replace(/'/g, "&apos;").replace(/"/g, "&quot;");
        return `
            <div class="card" onclick="abrirModal('${d.nome}', '${desc}', '${img}')">
                <img src="${img}" alt="${d.nome}">
                <div class="card-content">
                    <h3>${d.nome}</h3>
                    <p style="margin:5px 0; color:#777"><i>${d.especie}</i></p>
                    <p style="margin:0; font-weight:bold; color:#bf3535">📍 ${d.regiao}</p>
                </div>
            </div>`;
    }).join('');
}


function abrirModalCadastro() { document.getElementById('modalCadastro').style.display = "block"; }
function fecharModalCadastro() { document.getElementById('modalCadastro').style.display = "none"; }

async function salvarDino() {
    const novo = {
        nome: document.getElementById('nome').value,
        especie: document.getElementById('especie').value,
        regiao: document.getElementById('regiao').value,
        eraId: document.getElementById('eraIdSelect').value,
        imagemUrl: document.getElementById('imagemUrl').value,
        descricao: document.getElementById('descricao').value
    };

    try {
        await fetch(`${API_URL}/Dinossauro`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(novo)
        });
        fecharModalCadastro();
        carregarDados();
        limparFormulario();
    } catch (e) { console.error("Erro ao salvar:", e); }
}

function limparFormulario() {
    ["nome", "especie", "regiao", "imagemUrl", "descricao"].forEach(id => {
        document.getElementById(id).value = "";
    });
}

function abrirModal(n, d, i) {
    document.getElementById('modalNome').innerText = n;
    document.getElementById('modalDescricao').innerText = d;
    document.getElementById('modalImg').src = i;
    document.getElementById('meuModal').style.display = "block";
}

function fecharModal() { document.getElementById('meuModal').style.display = "none"; }

window.onclick = e => { 
    if (e.target == document.getElementById('meuModal')) fecharModal();
    if (e.target == document.getElementById('modalCadastro')) fecharModalCadastro();
}

function filtrarPorEra(id) {
    exibirDinos(id === 'todas' ? todosOsDinos : todosOsDinos.filter(d => d.eraId === id));
}

function buscar() {
    const t = document.getElementById('inputBusca').value.toLowerCase();
    exibirDinos(todosOsDinos.filter(d => 
        d.nome.toLowerCase().includes(t) || d.especie.toLowerCase().includes(t)
    ));
}

carregarDados();