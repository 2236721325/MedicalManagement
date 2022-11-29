<template>
	<div>
		<div class="container">
			<div class="handle-box">
				<el-input v-model="searchDto.id" type="number"  placeholder="ID" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.name" placeholder="姓名" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.idCard" placeholder="身份证" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.educationalBackground" placeholder="学历" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.professionalTitle" placeholder="职称" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.department" placeholder="科室" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.phoneNumber" placeholder="电话" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.address" placeholder="住址" class="handle-input mr10"></el-input>
				<el-button type="primary" :icon="Search" @click="handleSearch">搜索</el-button>
				<el-button type="primary" :icon="Plus" @click="handleAdd">新增</el-button>
			</div>
			<el-table :data="tableData" border class="table" ref="multipleTable" header-cell-class-name="table-header">
				<el-table-column prop="id" label="ID" width="55" align="center"></el-table-column>
				<el-table-column prop="name" label="姓名"></el-table-column>
				<el-table-column prop="idCard" label="身份证"></el-table-column>
				<el-table-column prop="educationalBackground" label="学历"></el-table-column>
				<el-table-column prop="professionalTitle" label="职称"></el-table-column>
				<el-table-column prop="department" label="科室"></el-table-column>
				<el-table-column prop="phoneNumber" label="电话"></el-table-column>
				<el-table-column prop="address" label="住址"></el-table-column>
				<!-- <el-table-column prop="createTime" label="注册时间"></el-table-column> -->
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
			<el-form label-width="70px" ref="ruleFormRef" :rules="rules" :model="formEdit">
					<el-form-item label="姓名" prop="name">
						<el-input v-model="formEdit.name"></el-input>
					</el-form-item>
					<el-form-item label="身份证号" prop="idCard">
						<el-input v-model="formEdit.idCard"></el-input>
					</el-form-item>
					<el-form-item label="学历" prop="educationalBackground">
						<el-input v-model="formEdit.educationalBackground"></el-input>
					</el-form-item>
					<el-form-item label="职称" prop="professionalTitle">
						<el-input v-model="formEdit.professionalTitle"></el-input>
					</el-form-item>
					<el-form-item label="科室" prop="department">
						<el-input v-model="formEdit.department"></el-input>
					</el-form-item>
					<el-form-item label="电话" prop="phoneNumber">
						<el-input v-model="formEdit.phoneNumber"></el-input>
					</el-form-item>
					<el-form-item label="住址" prop="address">
						<el-input v-model="formEdit.address"></el-input>
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
			<el-form label-width="70px" ref="ruleFormRef" :rules="rules" :model="formAdd">
				<el-form-item label="姓名" prop="name">
					<el-input v-model="formAdd.name"></el-input>
				</el-form-item>
				<el-form-item label="身份证号" prop="idCard">
					<el-input v-model="formAdd.idCard"></el-input>
				</el-form-item>
				<el-form-item label="学历" prop="educationalBackground">
					<el-input v-model="formAdd.educationalBackground"></el-input>
				</el-form-item>
				<el-form-item label="职称" prop="professionalTitle">
					<el-input v-model="formAdd.professionalTitle"></el-input>
				</el-form-item>
				<el-form-item label="科室" prop="department">
					<el-input v-model="formAdd.department"></el-input>
				</el-form-item>
				<el-form-item label="电话" prop="phoneNumber">
					<el-input v-model="formAdd.phoneNumber"></el-input>
				</el-form-item>
				<el-form-item label="住址" prop="address">
					<el-input v-model="formAdd.address"></el-input>
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
import { DoctorInfoApi, DoctorInfoCreateDto, DoctorInfoDto, DoctorInfoDtoPagedListDto, DoctorInfoUpdateDto, GetPagedListDto } from "../api-services";
import { getAPI, feature } from "../axios-utils"; // 注意项目的路径
import { request } from 'http';
console.log("api request completed.");


const query = reactive({
	pageIndex: 1,
	pageSize: 12,
});
const searchDto=ref<DoctorInfoDto>({});
const ruleFormRef = ref<FormInstance>();
const rules = reactive<FormRules>(
	{
		name: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		idCard: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		educationalBackground: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		professionalTitle: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		department: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		phoneNumber: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		address: [{ required: true, message: "输入不为空!", trigger: 'blur' }],

	}
)




const tableData = ref<DoctorInfoDto[]>();
const pageTotal = ref<number | undefined>(0);
// 获取表格数据
const getData = async () => {

	var getPagedListDto: GetPagedListDto =
	{
		skipCount: (query.pageIndex - 1) * query.pageSize,
		takeCount: query.pageSize
	}
	const [err, res] = await feature(getAPI(DoctorInfoApi)
		.apiDoctorInfoGetPagedListPost(getPagedListDto));
	if (err) {
		console.log(err);
	} else {
		tableData.value = res.data.result?.items;
		pageTotal.value = res.data.result?.totalCount;
	}
};
getData();

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
			'Name':searchDto.value.name,
			'Address':searchDto.value.address,
			'EducationalBackground':searchDto.value.educationalBackground,
			'PhoneNumber':searchDto.value.phoneNumber,
			'ProfessionalTitle':searchDto.value.professionalTitle,
			'IdCard':searchDto.value.idCard,
			'Department':searchDto.value.department
		}
	}
	console.log(getPagedListDto);
	const [err, res] = await feature(getAPI(DoctorInfoApi)
		.apiDoctorInfoGetPagedListPost(getPagedListDto));
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
		const [err, res] = await feature(getAPI(DoctorInfoApi)
			.apiDoctorInfoDeleteIdDelete(id));
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

let formEdit = ref<DoctorInfoUpdateDto>({
});
let formAdd = ref<DoctorInfoCreateDto>({});
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
	formEdit.value =JSON.parse(JSON.stringify(row));
	editVisible.value = true;
};
const saveAdd = async (formEl: FormInstance | undefined) => {
	if (!formEl) return;
	await formEl.validate(async (valid, fields) => {
		if (valid) {
			const [err, res] = await feature(getAPI(DoctorInfoApi)
				.apiDoctorInfoInsertPost(formAdd.value));
			if (err) {
				ElMessage.error(err.message);
			}
			else {
				if (res.status) {
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
			const [err, res] = await feature(getAPI(DoctorInfoApi)
				.apiDoctorInfoUpdatePut(formEdit.value));
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
