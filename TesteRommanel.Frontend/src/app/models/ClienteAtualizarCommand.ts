import { ClienteInserirCommand } from "./ClienteInserirCommand";

export class ClienteAtualizarCommand extends ClienteInserirCommand {
    
    constructor() {
        super();

        this.Id = 0;
    }

    Id: number;
}