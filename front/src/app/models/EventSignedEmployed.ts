export interface IEventSignedEmployed {
    id: string;
    eventId: string;
    userId: string;
}

export class EventSignedEmplyed implements IEventSignedEmployed{
    id: string;
    eventId: string;
    userId: string;

    constructor(idEvent: string, idUser: string){
        this.eventId=idEvent;
        this.userId=idUser;
    }

}