
export interface Course {
    id: number;
    nameOfCourse: string;
    courseCode: string;
    definition: string;
    photoUrl: string;
    lastAccessed: Date;
    announcements:Announcements[];
    courseFiles: CourseFiles[];
    lectureVideos: LectureVideos[];
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
export interface LectureVideos {
    id: number;
    url: string;
    nameOfVideo: string;
}
