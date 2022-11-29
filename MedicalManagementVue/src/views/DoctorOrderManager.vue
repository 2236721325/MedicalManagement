<template>
	<div>
		<div class="container">
			<div class="handle-box">
				<el-input v-model="searchDto.id" type="number"  placeholder="ID" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.doctorInfoId" type="number" placeholder="医生ID" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.patientInfoId" type="number" placeholder="病人ID" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.recordContent" placeholder="医嘱记录" class="handle-input mr10"></el-input>
				<el-button type="primary" :icon="Search" @click="handleSearch">搜索</el-button>
				<el-button type="primary" :icon="Plus" @click="handleAdd">新增</el-button>
			</div>
			<el-table :data="tableData" border class="table" ref="multipleTable" header-cell-class-name="table-header">
				<el-table-column prop="id" label="ID" width="55" align="center"></el-table-column>
				<el-table-column prop="doctorInfoId" label="医生ID"></el-table-column>
				<el-table-column prop="patientInfoId" label="病人ID"></el-table-column>
				<el-table-column prop="recordContent" label="医嘱记录"></el-table-column>
				<el-table-column prop="createDate"  label="创建时间" ></el-table-column>
				<el-table-column label="操作" width="220" align="center">
					<template #default="scope">
						<el-button text :icon="Edit" @click="handleEdit(scope.$index, scope.row)">
							编辑
						</el-button>
						<el-button text :icon="Delete" class="red" @click="handleDelete(scope.$index)">
							删除
						</el-button>
					</template>
				</el-table-column>
			</el-table>
			<div class="pagination">
				<el-pagination background layout="total, prev, pager, next" :current-page="query.pageIndex"
					:page-size="query.pageSize" :total="pageTotal" @current-change="handlePageChange"></el-pagination>
			</div>
		</div>

		<!-- 编辑弹出框 -->
		<el-dialog title="编辑" v-model="editVisible" width="30%">
			<el-form label-width="100px" ref="ruleFormRef" :rules="rules" :model="formEdit">
				<el-form-item label="医生ID" prop="doctorInfoId">
					<el-input v-model="formEdit.doctorInfoId"></el-input>
				</el-form-item>
				<el-form-item label="病人ID" prop="patientInfoId">
					<el-input v-model="formEdit.patientInfoId"></el-input>
				</el-form-item>
				<el-form-item label="医嘱记录" prop="recordContent">
					<el-input v-model="formEdit.recordContent"></el-input>
				</el-form-item>

			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="editVisible = false">取 消</el-button>
					<el-button type="primary" @click="saveEdit(ruleFormRef)">确 定</el-button>
				</span>
			</template>
		</el-dialog>
		<el-dialog title="新增" v-model="addVisible" width="30%">
			<el-form label-width="100px" ref="ruleFormRef" :rules="rules" :model="formAdd">
				<el-form-item label="医生ID" prop="doctorInfoId">
					<el-input v-model="formAdd.doctorInfoId"></el-input>
				</el-form-item>
				<el-form-item label="病人ID" prop="patientInfoId">
					<el-input v-model="formAdd.patientInfoId"></el-input>
				</el-form-item>
				<el-form-item label="医嘱记录" prop="recordContent">
					<el-input v-model="formAdd.recordContent"></el-input>
				</el-form-item>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="addVisible = false">取 消</el-button>
					<el-button type="primary" @click="saveAdd(ruleFormRef)">确 定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script setup lang="ts" name="basetable">
import { ref, reactive } from 'vue';
import { ElMessage, ElMessageBox, FormInstance, FormRules, messageConfig } from 'element-plus';
import { Delete, Edit, Search, Plus } from '@element-plus/icons-vue';
import { DoctorAdviceInfoApi, DoctorAdviceInfoCreateDto, DoctorAdviceInfoDto, DoctorAdviceInfoDtoPagedListDto, DoctorAdviceInfoUpdateDto, GetPagedListDto } from "../api-services";
import { getAPI, feature } from "../axios-utils"; // 注意项目的路径
import { request } from 'http';
console.log("api request completed.");


const query = reactive({
	name: '',
	pageIndex: 1,
	pageSize: 12
});
const ruleFormRef = ref<FormInstance>();
const rules = reactive<FormRules>(
	{
		doctorInfoId: [
			{ required: true, message: "输入不为空!", trigger: 'blur' },
			{
				validator(rule, value, callback) {
					if (/(^[1-9]\d*$)/.test(value)) {
						callback()
					} else {
						callback(new Error('请输入正整数'))
					}
				},
				trigger: 'blur'
			}

		],
		patientInfoId: [
			{ required: true, message: "输入不为空!", trigger: 'blur' },
			{
				validator(rule, value, callback) {
					if (/(^[1-9]\d*$)/.test(value)) {
						callback()
					} else {
						callback(new Error('请输入正整数'))
					}
				},
				trigger: 'blur'
			}

		],

		recordContent: [{ required: true, message: "输入不为空!", trigger: 'blur' }],

	}
)




const tableData = ref<DoctorAdviceInfoDto[]>();
const pageTotal = ref<number | undefined>(0);
// 获取表格数据
const getData = async () => {

	var getPagedListDto: GetPagedListDto =
	{
		skipCount: (query.pageIndex - 1) * query.pageSize,
		takeCount: query.pageSize
	}
	const [err, res] = await feature(getAPI(DoctorAdviceInfoApi)
		.apiDoctorAdviceInfoGetPagedListPost(getPagedListDto));
	if (err) {
		console.log(err);
	} else {
		tableData.value = res.data.result?.items;
		pageTotal.value = res.data.result?.totalCount;
	}
};
getData();

const searchDto =ref<DoctorAdviceInfoDto>({});
// 查询操作
const handleSearch = async () => {
	query.pageIndex = 1;
	console.log(searchDto.value);
	var getPagedListDto: GetPagedListDto =
	{
		skipCount: (query.pageIndex - 1) * query.pageSize,
		takeCount: query.pageSize,
		searchs:{
			'Id':searchDto.value.id?Number(searchDto.value.id):undefined,
			'DoctorInfoId':searchDto.value.doctorInfoId?Number(searchDto.value.doctorInfoId):undefined,
			'PatientInfoId':searchDto.value.patientInfoId?Number(searchDto.value.patientInfoId):undefined,
			'recordContent':searchDto.value.recordContent,
		}
	}
	console.log(getPagedListDto);
	const [err, res] = await feature(getAPI(DoctorAdviceInfoApi)
		.apiDoctorAdviceInfoGetPagedListPost(getPagedListDto));
	if (err) {
		console.log(err);
	} else {
		tableData.value = res.data.result?.items;
		pageTotal.value = res.data.result?.totalCount;
	}

};
// 分页导航
const handlePageChange = (val: number) => {
	query.pageIndex = val;
	getData();
};

// 删除操作
const handleDelete = async (index: number) => {
	// 二次确认删除
	let id: number = tableData.value[index].id;
	ElMessageBox.confirm('确定要删除吗？', '提示', {
		type: 'warning'
	}).then(async () => {
		const [err, res] = await feature(getAPI(DoctorAdviceInfoApi)
			.apiDoctorAdviceInfoDeleteIdDelete(id));
		if (err) {
			console.log(err);
		} else {
			ElMessage.success('删除成功');
			getData();

		}
	})
};

// 表格编辑时弹窗和保存
const editVisible = ref(false);
const addVisible = ref(false);

let formEdit = ref<DoctorAdviceInfoUpdateDto>({
});
let formAdd = ref<DoctorAdviceInfoCreateDto>({});
let idx: number = -1;
let currentId: number = -1;
const handleAdd = () => {
	formAdd.value = {};
	addVisible.value = true;
}
const handleEdit = (index: number, row: any) => {
	idx = index;
	currentId = row.id;
	//通过json实现深拷贝
	formEdit.value = JSON.parse(JSON.stringify(row));
	editVisible.value = true;
};
const saveAdd = async (formEl: FormInstance | undefined) => {
	if (!formEl) return;
	await formEl.validate(async (valid, fields) => {
		if (valid) {
			const [err, res] = await feature(getAPI(DoctorAdviceInfoApi)
				.apiDoctorAdviceInfoInsertPost(formAdd.value));
			if (err) {
				ElMessage.error(err.message);
			}
			else {
				if (res.data.status) {
					addVisible.value = false;
					ElMessage.success("添加成功！");
					getData();
				}
				else {
					ElMessage.error(res.data.message);
				}

			}

		} else {
			console.log('error submit!', fields)
		}
	})

};
const saveEdit = async (formEl: FormInstance | undefined) => {
	if (!formEl) return;
	await formEl.validate(async (valid, fields) => {
		if (valid) {
			tableData.value[idx] = formEdit.value;
			const [err, res] = await feature(getAPI(DoctorAdviceInfoApi)
				.apiDoctorAdviceInfoUpdatePut(formEdit.value));
			if (err) {
				console.log(err);
			} else {
				editVisible.value = false;
				getData();
				ElMessage.success("编辑成功！");
			}


		} else {
			console.log('error submit!', fields)
		}
	});

};
</script>

<style scoped>
.handle-box {
	margin-bottom: 20px;
}

.handle-select {
	width: 120px;
}

.handle-input {
	width: 300px;
}

.table {
	width: 100%;
	font-size: 14px;
}

.red {
	color: #ff0000;
}

.mr10 {
	margin-right: 10px;
}

.table-td-thumb {
	display: block;
	margin: auto;
	width: 40px;
	height: 40px;
}
</style>
