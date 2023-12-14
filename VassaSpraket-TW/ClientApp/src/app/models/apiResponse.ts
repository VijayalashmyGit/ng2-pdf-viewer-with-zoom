export class ApiResponse<T> {
  success: boolean;
  errorMessage: string;
  payload: T;
}
