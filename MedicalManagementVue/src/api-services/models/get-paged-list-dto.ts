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
/**
 * 
 * @export
 * @interface GetPagedListDto
 */
export interface GetPagedListDto {
    /**
     * 
     * @type {number}
     * @memberof GetPagedListDto
     */
    skipCount?: number;
    /**
     * 
     * @type {number}
     * @memberof GetPagedListDto
     */
    takeCount?: number;
    /**
     * 
     * @type {{ [key: string]: any; }}
     * @memberof GetPagedListDto
     */
    searchs?: { [key: string]: any; } | null;
}