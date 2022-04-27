
export interface Course {
    id: number;
    nameOfCourse: string;
    courseCode: string;
    definition: string;
    photoUrl: string;
    lastAccessed: Date;
    announcements:Announcements[];
    courseFiles: CourseFiles[];
}

export interface Announcements {
    announcement: string;
}
export interface CourseFiles {
    id: number;
    url: string;
    fileName: string;
}