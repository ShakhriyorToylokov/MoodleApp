import { Course } from "./course";

    export interface Student {
        id: number;
        username: string;
        name: string;
        surname: string;
        stdNum: string;
        photoUrl: string;
        email: string;
        country: string;
        gender: string;
        age: number;
        created: Date;
        lastActive: Date;
        faculty: string;
        photos: StdPhoto[];
        courses: Course[];
        homeworks: Homework[];
    }
    export interface StdPhoto {
        id: number;
        url: string;
        isMain: boolean;
    }
    export interface Homework {
        id: number;
        url: string;
        fileName: string;
        homeworkName: string;
    }

  

   

