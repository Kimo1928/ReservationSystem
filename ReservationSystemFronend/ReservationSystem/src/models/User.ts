export interface User {
    id:Number;
    name:string;
    mobile:string;
    userTopicAvaliabilityDTOs:userTopicAvaliabilityDTOs[];
}
export interface userTopicAvaliabilityDTOs {
    topicId:          number;
    avaliabilityFrom: string;
    avaliabilityTo:   string;
  }

export interface UserDto{
    name:string;
    mobile:string;
    userType:number;
    userTopicAvaliabilityDTOs:userTopicAvaliabilityDTOs[];

} 