import {  TeacherPhoto } from "./teacher";

export interface Course {
    id: number;
    nameOfCourse: string;
    courseCode: string;
    definition: string;
    photoUrl: string;
    announcements:Announcements[];
    courseFiles: CourseFiles[];
    quizFiles: QuizFiles[];
    lectureVideos: LectureVideos[];
    teacher:TeacherDto;
}
export interface TeacherDto{
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
    photos: TeacherPhoto[];
}
export interface Announcements {
    id:number;
    announcement: string;
}
export interface CourseFiles {
    id: number;
    url: string;
    fileName: string;
    isOutline: boolean;
}
export interface QuizFiles {
    id: number;
    url: string;
    fileName: string;
    time:number;
    quizDefinition:string;
}
export interface LectureVideos {
    id: number;
    url: string;
    nameOfVideo: string;
}
