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
import { MedicineInfoDtoPagedListDto } from './medicine-info-dto-paged-list-dto';
/**
 * 
 * @export
 * @interface MedicineInfoDtoPagedListDtoApiResult
 */
export interface MedicineInfoDtoPagedListDtoApiResult {
    /**
     * 
     * @type {string}
     * @memberof MedicineInfoDtoPagedListDtoApiResult
     */
    message?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof MedicineInfoDtoPagedListDtoApiResult
     */
    status?: boolean;
    /**
     * 
     * @type {MedicineInfoDtoPagedListDto}
     * @memberof MedicineInfoDtoPagedListDtoApiResult
     */
    result?: MedicineInfoDtoPagedListDto;
}
