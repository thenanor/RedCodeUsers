export interface Contact {    
    phone: string,
    address: string
}

export interface SaveUser {
    id: number,
    fullName: string,
    email: string,
    gender: string,
    interests: number[],
    contact: Contact
}

export interface User {
    id: number,
    fullName: string,
    email: string,
    gender: string,
    interests: any[],
    contact: Contact,
    registrationDate: string
}

export interface QueryResult {
    items: User[],
    totalItems: number
}
