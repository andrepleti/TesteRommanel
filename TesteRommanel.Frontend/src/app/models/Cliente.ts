export class Cliente {
    
    constructor() {
        this.Id = 0;
        this.NomeRazaoSocial = "";
        this.CpfCnpj = "";
        this.InscricaoEstadual = "";
        this.Isento = true;
        this.DataNascimento = null;
        this.Telefone = "";
        this.Email = "";
        this.Tipo = 1;
        this.Cep = "";
        this.Logradouro = "";
        this.Numero = "";
        this.Bairro = "";
        this.Cidade = "";
        this.Estado = "";
    }

    Id: number;
    NomeRazaoSocial: string;
    CpfCnpj: string;
    InscricaoEstadual: string;
    Isento: boolean;
    DataNascimento: Date | null;
    Telefone: string;
    Email: string;
    Tipo: number;
    Cep: string;
    Logradouro: string;
    Numero: string;
    Bairro: string;
    Cidade: string;
    Estado: string;
}

export namespace Cliente
{
    export enum ETipoPessoa {
        Fisica = 1,
        Juridica = 2
    }   
}