namespace MM.Shared.Enums;

public enum ReportType
{
    [FieldSettings("Desfazer o match", Description = "Apenas perdi o interesse por este perfil e quero desfazer o match")]
    NotInterested = 1,

    [FieldSettings("Informação Errada", Group = "Moderado|Poderá ser exibido publicamente no perfil", Description = "Denunciar algum informação errada no perfil (isso inclui informações das categorias: Básico, Bio e Lifestyle)")]
    Field = 2,

    [FieldSettings("Curving", Group = "Moderado|Poderá ser exibido publicamente no perfil", Description = "O 'curver' é aquela pessoa que te deixa em banho-maria; manda mensagens esporádicas, mas nunca está disposto a te ver, não convida pra sair e nem aceita convite. E, quando finalmente vocês combinam de sair, desmarca o encontro de última hora.")]
    Curving = 10,

    [FieldSettings("Ghosting", Group = "Moderado|Poderá ser exibido publicamente no perfil", Description = "O ghosting acontece quando a outra pessoa começa a ignorar, evitar, e também deixa de responder mensagens, não atende mais ligações e, sem aviso, desaparece sem apresentar motivos.")]
    Ghosting = 11,

    [FieldSettings("Obligaswiping", Group = "Moderado|Poderá ser exibido publicamente no perfil", Description = "É o que fazem essas pessoas que criam perfis em aplicativos de relacionamentos, mas, conscientemente ou não, não pretendem se encontrar e/ou se relacionar com alguém (geralmente entram para passar o tempo, aumentar o ego, etc);")]
    Obligaswiping = 12,

    [FieldSettings("Menor de Idade", Group = "Grave|Poderá ser banido da plataforma", Description = "Este perfil parece pertencer a alguém com menos de 18 anos (idade pode variar de acordo com as leis de cada país)")]
    Under18 = 20,

    [FieldSettings("Conteúdo Inapropriado", Group = "Grave|Poderá ser banido da plataforma", Description = "Conteúdo Inapropriado pode incluir: pornografia; violência; comportamento extremista; conteúdo ofensivo, como texto, fotos ou vídeos nos perfis; Conteúdo, texto ou fotos pertencentes a outra pessoa;")]
    InappropriateContent = 21,

    [FieldSettings("Comportamento Inapropriado", Group = "Grave|Poderá ser banido da plataforma", Description = "Comportamento Inapropriado pode incluir: Bullying online; Comentários inapropriados (racial ou sexualmente orientados); Envio de material inapropriado (adulto / ilegal / anti-social);")]
    InappropriateBehaviour = 22,

    [FieldSettings("Spam / Scam / Fake / Catfishing", Group = "Grave|Poderá ser banido da plataforma", Description = "Perfil com comportamento suspeito ou com intenções que violem nossos termos de uso. Exemplo: Solicitam informações pessoais sensíveis; Promovem produtos, serviços ou perfis de outras redes sociais; Solicitam dinheiro ou outros favores;")]
    SpamScamFakeCatfishing = 23
}