import { Course } from "./course";

    export interface Teacher {
        id: number;
        username: string;
        name: string;
        surname: string;
        insNum: string;
        photoUrl: string;
        email: string;
        country: string;
        gender: string;
        age: number;
        created: Date;
        lastActive: Date;
        faculty: string;
        courses: Course[];
        photos: TeacherPhoto[];
    }

    export interface TeacherPhoto {
        id: number;
        url: string;
        isMain: boolean;
    }


