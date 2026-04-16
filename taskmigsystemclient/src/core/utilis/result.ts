export interface Result<T>{
  value:T,
  message:string,
  statusCode:number,
  isSuccess:boolean,
  problemDetails:ProblemDetails,
} 

export interface ProblemDetails{
    title : string,
    detail : string,
    statusCode : number,
    type :string,
    instance : string
}