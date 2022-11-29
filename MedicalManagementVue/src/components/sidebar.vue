<template>
	<div class="sidebar">
		<el-menu class="sidebar-el-menu" :default-active="onRoutes" :collapse="sidebar.collapse"
			background-color="#324157" text-color="#bfcbd9" active-text-color="#20a0ff" unique-opened router>
			<div v-for="item in items">
				<el-menu-item :index="item.index">
					<el-icon>
						<component :is="item.icon"></component>
					</el-icon>
					<template #title>{{ item.title }}</template>
				</el-menu-item>
			</div>
		</el-menu>
	</div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { useSidebarStore } from '../store/sidebar';
import { useRoute } from 'vue-router';

const items = [
	{
		icon: 'Odometer',
		index: '/',
		title: '个人中心',
	},
	{
		icon: 'Odometer',
		index: '/DoctorManager',
		title: '医生信息管理',
	},
	{
		icon: 'Odometer',
		index: '/PatientManager',
		title: '病人信息管理',
	},
	{
		icon: 'Odometer',
		index: '/MedicalManager',
		title: '药品信息管理',
	},
	{
		icon: 'Odometer',
		index: '/MedicalOrderManager',
		title: '医嘱信息管理',
	},
	{
		icon: 'Odometer',
		index: '/PrescriptionManager',
		title: '处方信息管理',
	},
];


const route = useRoute();
const onRoutes = computed(() => {
	return route.path;
});

const sidebar = useSidebarStore();
</script>

<style scoped>
.sidebar {
	display: block;
	position: absolute;
	left: 0;
	top: 70px;
	bottom: 0;
	overflow-y: scroll;
}

.sidebar::-webkit-scrollbar {
	width: 0;
}

.sidebar-el-menu:not(.el-menu--collapse) {
	width: 250px;
}

.sidebar>ul {
	height: 100%;
}
</style>
