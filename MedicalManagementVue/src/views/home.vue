<template>
	<MyHeader/>
	<MySideBar />
	<div class="content-box" :class="{ 'content-collapse': sidebar.collapse }">
		<v-tags></v-tags>
		<div class="content">
			<router-view v-slot="{ Component }">
				<transition name="move" mode="out-in">
					<keep-alive :include="tags.nameList">
						<component :is="Component"></component>
					</keep-alive>
				</transition>
			</router-view>
		</div>
	</div>
</template>
<script setup lang="ts">
import  MyHeader  from "../components/header.vue";
import  MySideBar  from "../components/sidebar.vue";
import { useSidebarStore } from '../store/sidebar';
import { useTagsStore } from '../store/tags';

const sidebar = useSidebarStore();
const tags = useTagsStore();
</script>
