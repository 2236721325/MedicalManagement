/* tslint:disable */
/* eslint-disable */
/**
 * MedicalManagement.WebAPI
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { DoctorAdviceInfoDtoPagedListDto } from './doctor-advice-info-dto-paged-list-dto';
/**
 * 
 * @export
 * @interface DoctorAdviceInfoDtoPagedListDtoApiResult
 */
export interface DoctorAdviceInfoDtoPagedListDtoApiResult {
    /**
     * 
     * @type {string}
     * @memberof DoctorAdviceInfoDtoPagedListDtoApiResult
     */
    message?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof DoctorAdviceInfoDtoPagedListDtoApiResult
     */
    status?: boolean;
    /**
     * 
     * @type {DoctorAdviceInfoDtoPagedListDto}
     * @memberof DoctorAdviceInfoDtoPagedListDtoApiResult
     */
    result?: DoctorAdviceInfoDtoPagedListDto;
}
