export interface Admin {
    id: number;
    username: string;
    name: string;
    surname: string;
    email: string;
    adminType: string;
   registerFiles: RegisterFiles[]; 
}


export interface RegisterFiles {
    id: number;
    url: string;
    fileName: string;
}