
export interface Course {
    id: number;
    nameOfCourse: string;
    courseCode: string;
    definition: string;
    photoUrl: string;
    lastAccessed: Date;
    announcements:Announcements[];
}
export interface Announcements {
    announcement: string;
}