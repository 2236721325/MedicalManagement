<template>
	<div>
			<div class="container">
			<div class="handle-box">
				<el-input v-model="searchDto.id" type="number"  placeholder="ID" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.name"  placeholder="名称" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.catagory"  placeholder="医药类别" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.price" type="number" placeholder="价格" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.manufacturer"  placeholder="生产厂家" class="handle-input mr10"></el-input>
				<el-input v-model="searchDto.specification"  placeholder="规格" class="handle-input mr10"></el-input>

				<el-button type="primary" :icon="Search" @click="handleSearch">搜索</el-button>
				<el-button type="primary" :icon="Plus" @click="handleAdd">新增</el-button>
			</div>
			<el-table :data="tableData" border class="table" ref="multipleTable" header-cell-class-name="table-header">
				<el-table-column prop="id" label="ID" width="55" align="center"></el-table-column>
				<el-table-column prop="name" label="名称"></el-table-column>
				<el-table-column prop="catagory" label="医药类别"></el-table-column>
				<el-table-column prop="price" label="价格"></el-table-column>
				<el-table-column prop="manufacturer" label="生产厂家"></el-table-column>
				<el-table-column prop="specification" label="规格"></el-table-column>
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
				<el-form-item label="名称" prop="name">
					<el-input v-model="formEdit.name"></el-input>
				</el-form-item>
				<el-form-item label="医药类别" prop="catagory">
					<el-input v-model="formEdit.catagory"></el-input>
				</el-form-item>
				<el-form-item label="价格" prop="price">
					<el-input type="number" v-model="formEdit.price"></el-input>
				</el-form-item>
				<el-form-item label="生产厂家" prop="manufacturer">
					<el-input v-model="formEdit.manufacturer"></el-input>
				</el-form-item>
				<el-form-item label="规格" prop="specification">
					<el-input v-model="formEdit.specification"></el-input>
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
				<el-form-item label="名称" prop="name">
					<el-input v-model="formAdd.name"></el-input>
				</el-form-item>
				<el-form-item label="医药类别" prop="catagory">
					<el-input v-model="formAdd.catagory"></el-input>
				</el-form-item>
				<el-form-item label="价格" prop="price">
					<el-input type="number" v-model="formAdd.price"></el-input>
				</el-form-item>
				<el-form-item label="生产厂家" prop="manufacturer">
					<el-input v-model="formAdd.manufacturer"></el-input>
				</el-form-item>
				<el-form-item label="规格" prop="specification">
					<el-input v-model="formAdd.specification"></el-input>
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
import { getAPI, feature } from "../axios-utils"; // 注意项目的路径
import { MedicineInfoDto } from '../api-services/models/medicine-info-dto';
import { GetPagedListDto, MedicineInfoApi, MedicineInfoCreateDto, MedicineInfoUpdateDto } from '../api-services';
console.log("api request completed.");


const query = reactive({
	name: '',
	pageIndex: 1,
	pageSize: 12
});
const ruleFormRef = ref<FormInstance>();
const rules = reactive<FormRules>(
	{
		name: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		catagory: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		price: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		specification: [{ required: true, message: "输入不为空!", trigger: 'blur' }],
		manufacturer: [{ required: true, message: "输入不为空!", trigger: 'blur' }],

	}
)




const tableData = ref<MedicineInfoDto[]>();
const pageTotal = ref<number | undefined>(0);
// 获取表格数据
const getData = async () => {

	var getPagedListDto: GetPagedListDto =
	{
		skipCount: (query.pageIndex - 1) * query.pageSize,
		takeCount: query.pageSize
	}
	const [err, res] = await feature(getAPI(MedicineInfoApi)
		.apiMedicineInfoGetPagedListPost(getPagedListDto));
	if (err) {
		console.log(err);
	} else {
		tableData.value = res.data.result?.items;
		pageTotal.value = res.data.result?.totalCount;
	}
};
getData();

const searchDto =ref<MedicineInfoDto>({});
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
			'Price':searchDto.value.price?Number(searchDto.value.price):undefined,
			'manufacturer':searchDto.value.manufacturer,
			'Specification':searchDto.value.specification,
			'Catagory':searchDto.value.catagory,
			'Name':searchDto.value.name,

		}
	}
	console.log(getPagedListDto);
	const [err, res] = await feature(getAPI(MedicineInfoApi)
		.apiMedicineInfoGetPagedListPost(getPagedListDto));
	if (err) {
		console.log(err);
	} else {
		tableData.value = res.data.result?.items;
		pageTotal.value = res.data.result?.totalCount;
	}

};
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
		const [err, res] = await feature(getAPI(MedicineInfoApi)
			.apiMedicineInfoDeleteIdDelete(id));
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

let formEdit = ref<MedicineInfoUpdateDto>({
});
let formAdd = ref<MedicineInfoCreateDto>({});
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
			const [err, res] = await feature(getAPI(MedicineInfoApi)
				.apiMedicineInfoInsertPost(formAdd.value));
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
			const [err, res] = await feature(getAPI(MedicineInfoApi)
				.apiMedicineInfoUpdatePut(formEdit.value));
			if (err) {
				console.log(err);
			} else {
				editVisible.value = false;
				ElMessage.success("编辑成功！");
				getData();
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
